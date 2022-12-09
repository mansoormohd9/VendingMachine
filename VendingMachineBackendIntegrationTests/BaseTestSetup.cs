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

                    //var user = new User
                    //{
                    //    FirstName = "First",
                    //    LastName = "Last",
                    //    UserName = "admin@test.com",
                    //    NormalizedUserName = "admin@test.com".ToUpper(),
                    //    Email = "admin@test.com",
                    //    NormalizedEmail = "admin@test.com".ToUpper(),
                    //    EmailConfirmed = true,
                    //    PhoneNumber = "123456789",
                    //    PhoneNumberConfirmed = true,
                    //    LockoutEnabled = false,
                    //};
                    //PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                    //user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");
                    //await vendingMachineContext.Users.AddAsync(user);
                    //await vendingMachineContext.SaveChangesAsync();

                    //var adminRole = await vendingMachineContext.IdentityRoles.FirstOrDefaultAsync(x => x.NormalizedName == "ADMIN");

                    //await vendingMachineContext.IdentityUserRoles.AddAsync(new IdentityUserRole<string> { UserId = user.Id, RoleId = adminRole.Id });


                    //await vendingMachineContext.SaveChangesAsync();

                    //await vendingMachineContext.IdentityRoles.AddAsync(new Microsoft.AspNetCore.Identity.IdentityRole { Name = "ADMIN", NormalizedName = "ADMIN" });
                    //await vendingMachineContext.IdentityRoles.AddAsync(new Microsoft.AspNetCore.Identity.IdentityRole { Name = "BUYER", NormalizedName = "BUYER" });
                    //await vendingMachineContext.IdentityRoles.AddAsync(new Microsoft.AspNetCore.Identity.IdentityRole { Name = "SELLER", NormalizedName = "SELLER" });
                    //await vendingMachineContext.SaveChangesAsync();
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
