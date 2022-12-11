using Microsoft.Extensions.DependencyInjection;
using VendingMachineBackend.Models;

namespace VendingMachineBackendIntegrationTests.SeedData
{
    public static class SeedDeposits
    {
        public static async Task SeedDepositsData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var vendingMachineContext = provider.GetRequiredService<VendingMachineContext>())
                {
                    await vendingMachineContext.UserDeposits.AddRangeAsync(GetDeposits());
                    await vendingMachineContext.SaveChangesAsync();
                }
            }
        }

        private static IList<UserDeposit> GetDeposits()
        {
            return new List<UserDeposit>
            {
                new UserDeposit{DepositId = 1, Quantity = 1, UserId = Constants.BuyerRoleUserId },
                new UserDeposit{DepositId = 2,Quantity = 2, UserId = Constants.BuyerRoleUserId },
                new UserDeposit{DepositId = 5, Quantity = 1, UserId = Constants.BuyerRoleUserId },
            };
        }

        public static async Task Cleanup(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var vendingMachineContext = provider.GetRequiredService<VendingMachineContext>())
                {
                    vendingMachineContext.UserDeposits.RemoveRange(vendingMachineContext.UserDeposits);
                    await vendingMachineContext.SaveChangesAsync();
                }
            }
        }
    }
}
