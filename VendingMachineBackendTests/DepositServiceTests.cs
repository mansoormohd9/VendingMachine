using AutoMapper;
using Moq;
using System.Linq.Expressions;
using VendingMachineBackend.Models;
using VendingMachineBackend.Repositories;
using VendingMachineBackend.Services;
using VendingMachineBackend.Dtos;

namespace VendingMachineBackendTests
{
    [TestClass]
    public class DepositServiceTests
    {
        private readonly Mock<IUserDepositRepository> _mockUserDepositRepository = new Mock<IUserDepositRepository>();
        private readonly Mock<IDepositRepository> _mockDepositRepository = new Mock<IDepositRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        public IDepositService _depositService;

        [TestInitialize]
        public void TestInitialize()
        {
            _depositService = new DepositService(_mockDepositRepository.Object, _mockUserDepositRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public void TestGetDeposits()
        {
            //setup
            var userDeposits = new List<UserDeposit> { new UserDeposit() };
            _mockUserDepositRepository.Setup(x => x.Find(It.IsAny<Expression<Func<UserDeposit, bool>>>())).Returns(userDeposits.AsQueryable());

            //act
            var result = _depositService.GetDeposits(new User());

            //assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public async Task TestPostDepositsInvalid()
        {
            //setup
            var userDeposits = new List<Deposit> { new Deposit { Amount = 10M } };
            _mockDepositRepository.Setup(x => x.GetAll()).Returns(userDeposits.AsQueryable());

            //act
            var result = await _depositService.PostDeposit(new List<DepositDto> { new DepositDto {Deposit = 5M } });

            //assert
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public async Task TestPostDepositsISuccess()
        {
            //setup
            var deposits = new List<Deposit> { new Deposit { Amount = 10M } };
            var userDeposits = new List<UserDeposit> { new UserDeposit { DepositId = 1, Quantity = 5 } };
            _mockUserDepositRepository.Setup(x => x.Find(It.IsAny<Expression<Func<UserDeposit, bool>>>())).Returns(userDeposits.AsQueryable());
            _mockDepositRepository.Setup(x => x.GetAll()).Returns(deposits.AsQueryable());
            _mockUserDepositRepository.Setup(x => x.AddRangeAsync(It.IsAny<IEnumerable<UserDeposit>>())).Verifiable();
            _mockUserDepositRepository.Setup(x => x.UpdateRangeAsync(It.IsAny<IEnumerable<UserDeposit>>())).Verifiable();
            _mockMapper.Setup(x => x.Map<UserDeposit>(It.IsAny<DepositDto>())).Returns(new UserDeposit { DepositId = 1, Quantity = 10 });

            //act
            var result = await _depositService.PostDeposit(new List<DepositDto> { new DepositDto { Deposit = 10M } });

            //assert
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void TestDepositRemove()
        {
            //setup
            var userDeposits = new List<UserDeposit> { new UserDeposit() };
            _mockUserDepositRepository.Setup(x => x.Find(It.IsAny<Expression<Func<UserDeposit, bool>>>())).Returns(userDeposits.AsQueryable());
            _mockUserDepositRepository.Setup(x => x.RemoveRangeAsync(It.IsAny<IEnumerable<UserDeposit>>())).Verifiable();

            //act
            _depositService.ResetDeposit(new User());

            //assert
        }
    }
}
