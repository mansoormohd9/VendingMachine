using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;


namespace VendingMachineBackendIntegrationTests
{
    [TestClass]
    public class UnitTest1: BaseTestSetup
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var response = await _httpClient.GetAsync("WeatherForecast");

            var response1 = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(response);
        }
    }
}