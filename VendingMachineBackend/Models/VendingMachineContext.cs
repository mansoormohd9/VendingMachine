using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VendingMachineBackend.Helpers;

namespace VendingMachineBackend.Models
{
    public class VendingMachineContext : DbContext
    {
        public VendingMachineContext(DbContextOptions<VendingMachineContext> options)
        : base(options)
        {
        }

        public DbSet<IdentityUser> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData.SeedUsers(builder);
            SeedData.SeedRoles(builder);
            SeedData.SeedUserRoles(builder);
        }
    }
}
