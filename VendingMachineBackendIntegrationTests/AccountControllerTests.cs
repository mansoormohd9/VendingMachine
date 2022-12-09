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
    public class AccountControllerTests: BaseTestSetup
    {
        [TestMethod]
        public async Task TestSignUp()
        {
            //setup
            var signUpDto = new SingUpDto
            {
                FirstName = "First",
                LastName = "Last",
                Email = "test@test.com",
                Password = "Test@123",
                Role = "Buyer"
            };

            //act
            var response = await _httpClient.PostAsync("api/account/signup", new StringContent(JsonConvert.SerializeObject(signUpDto), Encoding.UTF8, MediaTypeNames.Application.Json));
            
            //assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task TestLogin()
        {
            //setup
            var signUpDto = new SingUpDto
            {
                FirstName = "First",
                LastName = "Last",
                Email = "test@test.com",
                Password = "Test@123",
                Role = "Buyer"
            };
            var loginDto = new LoginDto
            {
                Email = signUpDto.Email,
                Password = signUpDto.Password,
            };
            await _httpClient.PostAsync("api/account/signup", new StringContent(JsonConvert.SerializeObject(signUpDto), Encoding.UTF8, MediaTypeNames.Application.Json));

            var response = await _httpClient.PostAsync("api/account/login", new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, MediaTypeNames.Application.Json));
            
            var response1 = await response.Content.ReadAsStringAsync();

            //assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
