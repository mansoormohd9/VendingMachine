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
    public class BuyServiceTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository = new Mock<IProductRepository>();
        private readonly Mock<IUserDepositRepository> _mockUserDepositRepository = new Mock<IUserDepositRepository>();
        private readonly Mock<IDepositRepository> _mockDepositRepository = new Mock<IDepositRepository>();
        private readonly Mock<IUserBuyRepository> _mockUserBuyRepository = new Mock<IUserBuyRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        public IBuyService _buyService;

        [TestInitialize]
        public void TestInitialize()
        {
            _buyService = new BuyService(_mockUserDepositRepository.Object, _mockProductRepository.Object, _mockDepositRepository.Object, _mockMapper.Object, _mockUserBuyRepository.Object);
        }

        [TestMethod]
        public void TestCanBuyNullProduct()
        {
            //setup
            Product product = null;
            _mockProductRepository.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Product, bool>>>())).Returns(product);

            //assert
            var result = _buyService.CanBuy(new BuyDto(), new User());

            //act
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void TestCanBuyQuantityNotAvailable()
        {
            //setup
            Product product = new Product { AmountAvailable = 2 };
            _mockProductRepository.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Product, bool>>>())).Returns(product);

            //assert
            var result = _buyService.CanBuy(new BuyDto { Amount = 3 }, new User());

            //act
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void TestCanBuyQuantityAvailableFailure()
        {
            //setup
            Product product = new Product { AmountAvailable = 2, Cost = 115M };
            var userDeposits = new List<UserDeposit>
            {
                new UserDeposit{ Deposit = new Deposit{ Amount = 100 }, Quantity = 1, DepositId = 1 },
                new UserDeposit{ Deposit = new Deposit{ Amount = 5 }, Quantity = 1, DepositId = 2 }
            };
            _mockProductRepository.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Product, bool>>>())).Returns(product);
            _mockUserDepositRepository.Setup(x => x.Find(It.IsAny<Expression<Func<UserDeposit, bool>>>())).Returns(userDeposits.AsQueryable());

            //assert
            var result = _buyService.CanBuy(new BuyDto { Amount = 1 }, new User());

            //act
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void TestCanBuyQuantityAvailableSuccess()
        {
            //setup
            Product product = new Product { AmountAvailable = 2, Cost = 25M };
            var userDeposits = new List<UserDeposit>
            {
                new UserDeposit{ Deposit = new Deposit{ Amount = 100 }, Quantity = 1, DepositId = 1 },
                new UserDeposit{ Deposit = new Deposit{ Amount = 5 }, Quantity = 2, DepositId = 2 },
                new UserDeposit{ Deposit = new Deposit{ Amount = 10 }, Quantity = 10, DepositId = 3 },
                new UserDeposit{ Deposit = new Deposit{ Amount = 20 }, Quantity = 6, DepositId = 4 },
            };
            var deposits = new List<Deposit>
            {
                new Deposit { Amount = 100, Id = 1 },
                new Deposit { Amount = 5, Id = 2 },
                new Deposit { Amount = 10, Id = 3 },
                new Deposit { Amount = 20, Id = 4 },
            };
            _mockProductRepository.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Product, bool>>>())).Returns(product);
            _mockUserDepositRepository.Setup(x => x.Find(It.IsAny<Expression<Func<UserDeposit, bool>>>())).Returns(userDeposits.AsQueryable());
            _mockDepositRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Deposit, bool>>>())).Returns(deposits.AsQueryable());

            //assert
            var result = _buyService.CanBuy(new BuyDto { Amount = 1 }, new User());

            //act
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public async Task TestPlaceOrderFailure()
        {
            //setup
            Product product = new Product { AmountAvailable = 2 };
            _mockProductRepository.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<Product, bool>>>())).Returns(product);

            //assert
            var result = await _buyService.PlaceBuyOrderAsync(new BuyDto { Amount = 3 }, new User());

            //act
            Assert.AreEqual(false, result.Success);
        }
    }
}
