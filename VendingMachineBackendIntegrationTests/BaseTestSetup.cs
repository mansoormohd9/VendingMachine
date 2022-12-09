using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VendingMachineBackend.Helpers;
using VendingMachineBackend.Models;

namespace VendingMachineBackendIntegrationTests
{
    public class BaseTestSetup : IDisposable
    {
        public HttpClient _httpClient;

        [TestInitialize]
        public async Task Setup()
        {
            var application = new VendingMachineApiApplication();
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var vendingMachineContext = provider.GetRequiredService<VendingMachineContext>())
                {
                    await vendingMachineContext.Database.EnsureCreatedAsync();
                }
            }

            _httpClient = application.CreateClient();
        }

        [TestCleanup]
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
