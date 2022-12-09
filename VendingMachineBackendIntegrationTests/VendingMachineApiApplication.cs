using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using VendingMachineBackend.Models;

namespace VendingMachineBackendIntegrationTests
{
    public class VendingMachineApiApplication: WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<VendingMachineContext>));
                services.AddDbContext<VendingMachineContext>(options =>
                    options.UseInMemoryDatabase("TestingInMemory"));
            });

            return base.CreateHost(builder);
        }
    }
}
