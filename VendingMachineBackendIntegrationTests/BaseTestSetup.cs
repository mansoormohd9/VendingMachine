using Microsoft.AspNetCore.Mvc.Testing;

namespace VendingMachineBackendIntegrationTests
{
    public class BaseTestSetup : IDisposable
    {
        public HttpClient _httpClient;

        [TestInitialize]
        public void Setup()
        {
            var application = new WebApplicationFactory<Program>();
            _httpClient = application.CreateClient();
        }

        [TestCleanup]
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
