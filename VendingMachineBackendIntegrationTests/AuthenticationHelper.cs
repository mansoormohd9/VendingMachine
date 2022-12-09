using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;

namespace VendingMachineBackendIntegrationTests
{
    public static class AuthenticationHelper
    {
        public static async Task SignIn(HttpClient httpClient, SingUpDto signUpDto)
        {
            var loginDto = new LoginDto
            {
                Email = signUpDto.Email,
                Password = signUpDto.Password,
            };
            await httpClient.PostAsync("api/account/signup", new StringContent(JsonConvert.SerializeObject(signUpDto), Encoding.UTF8, MediaTypeNames.Application.Json));

            var response = await httpClient.PostAsync("api/account/login", new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, MediaTypeNames.Application.Json));
            var jwtToken = await response.Content.ReadAsStringAsync();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, jwtToken);
        }

        public static SingUpDto DummyUser()
        {
            return new SingUpDto
            {
                FirstName = "First",
                LastName = "Last",
                Email = "test@test.com",
                Password = "Test@123",
                Role = "Buyer"
            };
        }
    }
}
