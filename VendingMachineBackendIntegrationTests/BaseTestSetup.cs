using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VendingMachineBackend.Helpers;
using VendingMachineBackend.Models;

namespace VendingMachineBackendIntegrationTests
{
    public class BaseTestSetup : IDisposable
    {
        public HttpClient _httpClient;

        [TestInitialize]
        public void Setup()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // ... Configure test services
                    builder.ConfigureServices(services =>
                    {
                        services.AddDbContext<VendingMachineContext>(options =>
                        {
                            options.UseInMemoryDatabase("InMemoryDbForTesting");
                        });

                        
                    });
                });
            //await SeedData.Initialize(application.Services);
            _httpClient = application.CreateClient();
        }

        [TestCleanup]
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
