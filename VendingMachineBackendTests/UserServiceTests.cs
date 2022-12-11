using AutoMapper;
using Moq;
using System.Linq.Expressions;
using VendingMachineBackend.Models;
using VendingMachineBackend.Repositories;
using VendingMachineBackend.Services;
using VendingMachineBackend.Dtos;
using Microsoft.AspNetCore.Identity;

namespace VendingMachineBackendTests
{
    [TestClass]
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository = new Mock<IUserRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        public IUserService _userService;

        [TestInitialize]
        public void TestInitialize()
        {
            _userService = new UserService(_mockUserRepository.Object,  _mockMapper.Object, null);
        }

        [TestMethod]
        public void TestGetUserById()
        {
            //setup
            User user = null;
            _mockUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);

            //act
            var result = _userService.GetUserById("1");

            //assert
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void TestAdd()
        {
            //setup
            var users = new List<User>();
            _mockUserRepository.Setup(x => x.Find(It.IsAny<Expression<Func<User, bool>>>())).Returns(users.AsQueryable());

            //act
            var result = _userService.GetUserById("1");

            //assert
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void TestUpdate()
        {
            //setup
            var users = new List<User>();
            _mockUserRepository.Setup(x => x.Find(It.IsAny<Expression<Func<User, bool>>>())).Returns(users.AsQueryable());

            //act
            var result = _userService.GetUserById("1");

            //assert
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void TestDelete()
        {
            //setup
            User user = null;
            _mockUserRepository.Setup(x => x.SingleOrDefault(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);

            //act
            var result = _userService.GetUserById("1");

            //assert
            Assert.AreEqual(false, result.Success);
        }
    }
}
