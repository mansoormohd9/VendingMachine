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
    public class DepositControllerTests : BaseTestSetup
    {
        private readonly string apiBase = "api/deposits/";

        [TestInitialize]
        public async Task TestInitialize()
        {
            await SeedData.SeedUsers.SeedUsersData(_serviceProvider);
            await AuthenticationHelper.SignInAsync(_httpClient, AuthenticationHelper.GetBuyerUser());
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            await SeedData.SeedUsers.Cleanup(_serviceProvider);
        }

        [TestMethod]
        public async Task TestGetDeposits()
        {
            //setup
            var expected = HttpStatusCode.OK;

            //act
            var result = await _httpClient.GetAsync(apiBase);
            var response = JsonConvert.DeserializeObject<IEnumerable<DepositDto>>(await result.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(expected, result.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestPostDeposit()
        {
            //setup
            var expected = HttpStatusCode.NoContent;
            var deposits = new List<DepositDto>
            {
                new DepositDto { Deposit = 10M, Quantity = 2},
                new DepositDto { Deposit = 20M, Quantity = 2},
            };

            //act
            var depositsResult = await _httpClient.PostAsync(apiBase, new StringContent(JsonConvert.SerializeObject(deposits), Encoding.UTF8, MediaTypeNames.Application.Json));
            var getDepositsResult = await _httpClient.GetAsync(apiBase);
            var response = JsonConvert.DeserializeObject<IEnumerable<DepositDto>>(await getDepositsResult.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(expected, depositsResult.StatusCode);
            Assert.AreEqual(2, response.Count());
        }

        [TestMethod]
        public async Task TestResetDeposit()
        {
            //setup
            var expected = HttpStatusCode.NoContent;
            var deposits = new List<DepositDto>
            {
                new DepositDto { Deposit = 10M, Quantity = 2},
                new DepositDto { Deposit = 20M, Quantity = 2},
            };

            //act
            var depositsResult = await _httpClient.PostAsync(apiBase, new StringContent(JsonConvert.SerializeObject(deposits), Encoding.UTF8, MediaTypeNames.Application.Json));
            await _httpClient.PostAsync(apiBase + "reset", null);
            var getDepositsResult = await _httpClient.GetAsync(apiBase);
            var response = JsonConvert.DeserializeObject<IEnumerable<DepositDto>>(await getDepositsResult.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(expected, depositsResult.StatusCode);
            Assert.AreEqual(0, response.Count());
        }
    }
}
