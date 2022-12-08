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

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Deposit> Deposits { get; set; } = null!;
    }
}
