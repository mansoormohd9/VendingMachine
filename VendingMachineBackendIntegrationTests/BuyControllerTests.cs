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
    public class BuyControllerTests : BaseTestSetup
    {
        private readonly string apiBase = "api/buy/";

        [TestInitialize]
        public async Task TestInitialize()
        {
            await SeedData.SeedUsers.SeedUsersData(_serviceProvider);
            await SeedData.SeedProducts.SeedProductsData(_serviceProvider);
            await SeedData.SeedDeposits.SeedDepositsData(_serviceProvider);
            await AuthenticationHelper.SignInAsync(_httpClient, AuthenticationHelper.GetBuyerUser());
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            await SeedData.SeedProducts.Cleanup(_serviceProvider);
            await SeedData.SeedDeposits.Cleanup(_serviceProvider);
            await SeedData.SeedUsers.Cleanup(_serviceProvider);
        }

        [TestMethod]
        public async Task TestBuySuccess()
        {
            //setup
            var expected = HttpStatusCode.OK;
            var buyDto = new BuyDto
            {
                ProductId = 1,
                Amount = 1
            };

            //act
            var result = await _httpClient.PostAsync(apiBase, new StringContent(JsonConvert.SerializeObject(buyDto), Encoding.UTF8, MediaTypeNames.Application.Json));
            var response = JsonConvert.DeserializeObject<IEnumerable<DepositDto>>(await result.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(expected, result.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestBuyFailure()
        {
            //setup
            var expected = HttpStatusCode.BadRequest;
            var buyDto = new BuyDto
            {
                ProductId = 1,
                Amount = 3
            };

            //act
            var result = await _httpClient.PostAsync(apiBase, new StringContent(JsonConvert.SerializeObject(buyDto), Encoding.UTF8, MediaTypeNames.Application.Json));
            
            //assert
            Assert.AreEqual(expected, result.StatusCode);
        }

        [TestMethod]
        public async Task TestCanBuy()
        {
            //setup
            var expected = HttpStatusCode.OK;
            var buyDto = new BuyDto
            {
                ProductId = 1,
                Amount = 1
            };
            
            //act
            var result = await _httpClient.PostAsync(apiBase + "canBuy", new StringContent(JsonConvert.SerializeObject(buyDto), Encoding.UTF8, MediaTypeNames.Application.Json));
            var response = await result.Content.ReadAsStringAsync();

            //assert
            Assert.AreEqual(expected, result.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestCanBuyFail()
        {
            //setup
            var expected = HttpStatusCode.BadRequest;
            var buyDto = new BuyDto
            {
                ProductId = 1,
                Amount = 3
            };

            //act
            var result = await _httpClient.PostAsync(apiBase + "canBuy", new StringContent(JsonConvert.SerializeObject(buyDto), Encoding.UTF8, MediaTypeNames.Application.Json));
            
            //assert
            Assert.AreEqual(expected, result.StatusCode);
        }
    }
}
