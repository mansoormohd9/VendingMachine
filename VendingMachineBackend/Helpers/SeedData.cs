using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VendingMachineBackend.Models;

namespace VendingMachineBackend.Helpers
{
    //NOTES: TEMPORARY DATA FOR TESTING
    public class SeedData
    {
        private static string AdminUserId = "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7";
        private static string AdminRoleId = "83d8c9d4-610c-40c7-b26c-d0f23d708ee6";
        private static string SellerRoleId = "973c8158-4ca1-48e1-a1c9-5fcd4630cc41";
        private static string BuyerRoleId = "20b54706-1be9-473d-8a83-2cf57418e2c6";
        private static string AdminEmail = "ADMIN@TEST.COM";

        public static void SeedUsers(ModelBuilder builder)
        {
            var user = new User()
            {
                Id = AdminUserId,
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail,
                Email = AdminEmail,
                NormalizedEmail = AdminEmail,
                EmailConfirmed = true,
            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");

            builder.Entity<User>().HasData(user);
        }

        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = AdminRoleId, Name = "ADMIN", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = SellerRoleId, Name = "SELLER", ConcurrencyStamp = "2", NormalizedName = "SELLER" },
                new IdentityRole() { Id = BuyerRoleId, Name = "BUYER", ConcurrencyStamp = "3", NormalizedName = "BUYER" }
                );
        }

        public static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasKey(
                k => new { k.UserId, k.RoleId}
            );
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = AdminRoleId, UserId = AdminUserId }
            );
        }
    }
}
