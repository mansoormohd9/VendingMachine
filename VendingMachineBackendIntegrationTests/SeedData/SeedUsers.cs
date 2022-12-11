using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using VendingMachineBackend.Models;

namespace VendingMachineBackendIntegrationTests.SeedData
{
    public static class SeedUsers
    {
        public static async Task SeedUsersData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var vendingMachineContext = provider.GetRequiredService<VendingMachineContext>())
                {
                    await vendingMachineContext.Users.AddRangeAsync(GetUsers());
                    await vendingMachineContext.SaveChangesAsync();
                    var buyerRole = vendingMachineContext.IdentityRoles.First(x => x.Name == "BUYER").Id;
                    var buyerUserRole = new IdentityUserRole<string> { RoleId = buyerRole, UserId = Constants.SellerRoleUserId};
                    await vendingMachineContext.IdentityUserRoles.AddAsync(buyerUserRole);

                    var sellerRole = vendingMachineContext.IdentityRoles.First(x => x.Name == "SELLER").Id;
                    var sellerUserRole = new IdentityUserRole<string> { RoleId = sellerRole, UserId = Constants.SellerRoleUserId };
                    await vendingMachineContext.IdentityUserRoles.AddAsync(sellerUserRole);

                    await vendingMachineContext.SaveChangesAsync();
                }
            }
        }

        private static IList<User> GetUsers()
        {
            var passwordHasher = new PasswordHasher<User>();
            return new List<User>
            {
                new User{ Id = Constants.SellerRoleUserId, UserName = Constants.TestSellerUsername, NormalizedUserName = Constants.TestSellerUsername, NormalizedEmail = Constants.TestSellerUsername, Email = Constants.TestSellerUsername, PasswordHash = passwordHasher.HashPassword(null, Constants.TestPassword)},
                new User{ Id = Constants.BuyerRoleUserId, UserName = Constants.TestBuyerUsername, NormalizedUserName = Constants.TestBuyerUsername, NormalizedEmail = Constants.TestBuyerUsername, Email = Constants.TestBuyerUsername, PasswordHash = passwordHasher.HashPassword(null, Constants.TestPassword)},
            };
        }

        public static async Task Cleanup(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var vendingMachineContext = provider.GetRequiredService<VendingMachineContext>())
                {
                    vendingMachineContext.IdentityUserRoles.RemoveRange(vendingMachineContext.IdentityUserRoles);
                    vendingMachineContext.Users.RemoveRange(vendingMachineContext.Users);
                    await vendingMachineContext.SaveChangesAsync();
                }
            }
        }
    }
}
