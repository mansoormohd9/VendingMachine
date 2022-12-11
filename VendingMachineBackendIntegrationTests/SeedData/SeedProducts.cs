using Microsoft.Extensions.DependencyInjection;
using VendingMachineBackend.Models;

namespace VendingMachineBackendIntegrationTests.SeedData
{
    public static class SeedProducts
    {
        public static async Task SeedProductsData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var vendingMachineContext = provider.GetRequiredService<VendingMachineContext>())
                {
                    await vendingMachineContext.Products.AddRangeAsync(GetProducts());
                    await vendingMachineContext.SaveChangesAsync();
                }
            }
        }

        private static IList<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ Id = 1, Name = "Test1", AmountAvailable = 10, Cost = 10M, SellerId = Constants.SellerRoleUserId},
                new Product{ Id = 2, Name = "Test2", AmountAvailable = 10, Cost = 10M, SellerId = Constants.SellerRoleUserId},
                new Product{ Id = 3, Name = "Test3", AmountAvailable = 10, Cost = 10M, SellerId = Guid.NewGuid().ToString()},
            };
        }

        public static async Task Cleanup(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var vendingMachineContext = provider.GetRequiredService<VendingMachineContext>())
                {
                    vendingMachineContext.Products.RemoveRange(vendingMachineContext.Products);
                    await vendingMachineContext.SaveChangesAsync();
                }
            }
        }
    }
}
