using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using VendingMachineBackend.Dtos;

namespace VendingMachineBackendIntegrationTests
{
    [TestClass]
    public class ProductControllerTests : BaseTestSetup
    {
        private readonly string apiBase = "api/products/";

        [TestInitialize]
        public async Task TestInitialize()
        {
            await SeedData.SeedUsers.SeedUsersData(_serviceProvider);
            await SeedData.SeedProducts.SeedProductsData(_serviceProvider);
            await AuthenticationHelper.SignInAsync(_httpClient, AuthenticationHelper.GetSellerUser());
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            await SeedData.SeedUsers.Cleanup(_serviceProvider);
            await SeedData.SeedProducts.Cleanup(_serviceProvider);
        }

        [TestMethod]
        public async Task TestGetAll()
        {
            //setup
            var expected = HttpStatusCode.OK;

            //act
            var result = await _httpClient.GetAsync(apiBase);
            var response = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(await result.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(expected, result.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestGetProduct()
        {
            //setup
            var expected = HttpStatusCode.OK;

            //act
            var result = await _httpClient.GetAsync(apiBase + 2);
            var response = JsonConvert.DeserializeObject<ProductDto>(await result.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(expected, result.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestGetProductFail()
        {
            //setup
            var expected = HttpStatusCode.BadRequest;

            //act
            var result = await _httpClient.GetAsync(apiBase + 3);

            //assert
            Assert.AreEqual(expected, result.StatusCode);
        }

        [TestMethod]
        public async Task TestPostProduct()
        {
            //setup
            var expected = HttpStatusCode.NoContent;
            var productDto = new ProductSaveDto
            {
                Name = "NewName",
                AmountAvailable = 10,
                Cost = 10M
            };

            //act
            var result = await _httpClient.PostAsync(apiBase, new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, MediaTypeNames.Application.Json));
            
            //assert
            Assert.AreEqual(expected, result.StatusCode);
        }

        [TestMethod]
        public async Task TestPutProduct()
        {
            //setup
            var expected = HttpStatusCode.NoContent;
            var productDto = new ProductSaveDto
            {
                Name = "NewName",
                AmountAvailable = 10,
                Cost = 10M
            };

            //act
            var result = await _httpClient.PutAsync(apiBase + 2, new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, MediaTypeNames.Application.Json));

            //assert
            Assert.AreEqual(expected, result.StatusCode);
        }

        [TestMethod]
        public async Task TestPutProductFailForDifferentSeller()
        {
            //setup
            var expected = HttpStatusCode.BadRequest;
            var productDto = new ProductSaveDto
            {
                Name = "NewName",
                AmountAvailable = 10,
                Cost = 10M
            };

            //act
            var result = await _httpClient.PutAsync(apiBase + 3, new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, MediaTypeNames.Application.Json));

            //assert
            Assert.AreEqual(expected, result.StatusCode);
        }

        [TestMethod]
        public async Task TestDelete()
        {
            //setup
            var expected = HttpStatusCode.OK;

            //act
            var result = await _httpClient.GetAsync(apiBase + 2);

            //assert
            Assert.AreEqual(expected, result.StatusCode);
        }

        [TestMethod]
        public async Task TestDeleteFailForDifferentUser()
        {
            //setup
            var expected = HttpStatusCode.BadRequest;

            //act
            var result = await _httpClient.GetAsync(apiBase + 3);

            //assert
            Assert.AreEqual(expected, result.StatusCode);
        }
    }
}
