using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VendingMachineBackend.Models;

namespace VendingMachineBackend.Helpers
{
    //NOTES: TEMPORARY DATA FOR TESTING
    public static class SeedData
    {
        private static Guid AdminUserId = Guid.NewGuid();
        private static Guid AdminRoleId = Guid.NewGuid();
        //private static Guid SellerRoleId = "973c8158-4ca1-48e1-a1c9-5fcd4630cc41";
        //private static Guid BuyerRoleId = "20b54706-1be9-473d-8a83-2cf57418e2c6";

        public static void SeedUsers(ModelBuilder builder)
        {
            User user = new User
            {
                Id = AdminUserId.ToString(),
                Email = "admin@test.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            passwordHasher.HashPassword(user, "Admin*123");

            builder.Entity<IdentityUser>().HasData(user);
        }

        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole<string>() { Id = "sdf", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole<string>() { Id = "ssdf", Name = "Seller", ConcurrencyStamp = "2", NormalizedName = "Seller" },
                new IdentityRole<string>() { Id = "", Name = "Buyer", ConcurrencyStamp = "3", NormalizedName = "Buyer" }
                );
        }

        public static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<Guid>>().HasKey(u => new { u.RoleId, u.UserId });
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>() { RoleId = AdminRoleId, UserId = AdminUserId }
            );
        }
    }
}
