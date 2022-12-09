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
    public class UserControllerTests: BaseTestSetup
    {
        private readonly string apiBase = "api/users/";
        [TestInitialize]
        public async Task TestInitialize()
        {
            await AuthenticationHelper.SignInAsync(_httpClient, AuthenticationHelper.DummyUser());
        }

        [TestMethod]
        public async Task TestGet()
        {
            //setup
            var expected = HttpStatusCode.OK;

            //act
            var result = await _httpClient.GetAsync(apiBase);
            var response = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(await result.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(expected, result.StatusCode);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestSaveFail()
        {
            //setup
            var testUser = new UserDto
            {
                FirstName = "First",
                LastName = "Last",
                Email = "test@test.com",
                Role = "Buyer"
            };

            //act
            var result = await _httpClient.PostAsync(apiBase, new StringContent(JsonConvert.SerializeObject(testUser), Encoding.UTF8, MediaTypeNames.Application.Json));
            
            //assert
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public async Task TestSaveSuccess()
        {
            //setup
            var testUser = new UserDto
            {
                FirstName = "First",
                LastName = "Last",
                Email = "test1@test.com",
                Role = "Buyer"
            };

            //act
            var result = await _httpClient.PostAsync(apiBase, new StringContent(JsonConvert.SerializeObject(testUser), Encoding.UTF8, MediaTypeNames.Application.Json));
            var createdId = await result.Content.ReadAsStringAsync();


            //assert
            Assert.IsTrue(!string.IsNullOrEmpty(createdId));
        }

        [TestMethod]
        public async Task TestGetById()
        {
            //setup
            var testUser = new UserDto
            {
                FirstName = "First",
                LastName = "Last",
                Email = "test1@test.com",
                Role = "Buyer"
            };

            //act
            var result = await _httpClient.PostAsync(apiBase, new StringContent(JsonConvert.SerializeObject(testUser), Encoding.UTF8, MediaTypeNames.Application.Json));
            var createdId = await result.Content.ReadAsStringAsync();
            var fetchCreatedUser = await _httpClient.GetAsync(apiBase + createdId);
            var fetchCreated = JsonConvert.DeserializeObject<UserDto>(await fetchCreatedUser.Content.ReadAsStringAsync());


            //assert
            Assert.IsNotNull(fetchCreated);
        }

        [TestMethod]
        public async Task TestDelete()
        {
            //setup
            var testUser = new UserDto
            {
                FirstName = "First",
                LastName = "Last",
                Email = "test1@test.com",
                Role = "Buyer"
            };

            //act
            var result = await _httpClient.PostAsync(apiBase, new StringContent(JsonConvert.SerializeObject(testUser), Encoding.UTF8, MediaTypeNames.Application.Json));
            var createdId = await result.Content.ReadAsStringAsync();
            var deleteCreated = await _httpClient.DeleteAsync(apiBase + createdId);


            //assert
            Assert.AreEqual(HttpStatusCode.NoContent, deleteCreated.StatusCode);
        }
    }
}
