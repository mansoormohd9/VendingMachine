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
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository = new Mock<IProductRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        public IProductService _productService;

        [TestInitialize]
        public void TestInitialize()
        {
            _productService = new ProductService(_mockProductRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task TestAddFailure()
        {
            //setup
            var products = new List<Product> { new Product() };
            _mockProductRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Product, bool>>>())).Returns(products.AsQueryable());

            //act
            var result = await _productService.AddAsync(new ProductSaveDto());

            //assert
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public async Task TestAddSuccess()
        {
            //setup
            var products = new List<Product>();
            _mockProductRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Product, bool>>>())).Returns(products.AsQueryable());
            _mockProductRepository.Setup(x => x.AddAsync(It.IsAny<Product>())).Verifiable();

            //act
            var result = await _productService.AddAsync(new ProductSaveDto());

            //assert
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public async Task TestUpdateFailure()
        {
            //setup
            Product product = null;
            _mockProductRepository.Setup(x => x.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(product));

            //act
            var result = await _productService.UpdateAsync(1, new ProductSaveDto(), new User());

            //assert
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public async Task TestUpdateFailureSellerIdMismatch()
        {
            //setup
            Product product = new Product { SellerId = "1" };
            _mockProductRepository.Setup(x => x.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(product));

            //act
            var result = await _productService.UpdateAsync(1, new ProductSaveDto { }, new User { Id = "2" });

            //assert
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public async Task TestUDeleteFailure()
        {
            //setup
            Product product = null;
            _mockProductRepository.Setup(x => x.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(product));

            //act
            var result = await _productService.DeleteAsync(1, new User());

            //assert
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public async Task TestDeleteFailureSellerIdMismatch()
        {
            //setup
            Product product = new Product { SellerId = "1" };
            _mockProductRepository.Setup(x => x.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(product));

            //act
            var result = await _productService.DeleteAsync(1, new User { Id = "2" });

            //assert
            Assert.AreEqual(false, result.Success);
        }
    }
}
