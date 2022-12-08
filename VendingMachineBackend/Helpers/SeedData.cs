using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace VendingMachineBackend.Helpers
{
    //NOTES: TEMPORARY DATA FOR TESTING
    public static class SeedData
    {
        private static string AdminUserId = "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7";
        private static string AdminRoleId = "83d8c9d4-610c-40c7-b26c-d0f23d708ee6";
        private static string SellerRoleId = "973c8158-4ca1-48e1-a1c9-5fcd4630cc41";
        private static string BuyerRoleId = "20b54706-1be9-473d-8a83-2cf57418e2c6";

        public static void SeedUsers(ModelBuilder builder)
        {
            IdentityUser user = new IdentityUser()
            {
                Id = AdminUserId,
                UserName = "Admin",
                Email = "admin@test.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            passwordHasher.HashPassword(user, "Admin*123");

            builder.Entity<IdentityUser>().HasData(user);
        }

        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = AdminRoleId, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = SellerRoleId, Name = "Seller", ConcurrencyStamp = "2", NormalizedName = "Seller" },
                new IdentityRole() { Id = BuyerRoleId, Name = "Buyer", ConcurrencyStamp = "3", NormalizedName = "Buyer" }
                );
        }

        public static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = AdminRoleId, UserId = AdminUserId }
            );
        }
    }
}
