﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VendingMachineBackend.Helpers;

namespace VendingMachineBackend.Models
{
    public class VendingMachineContext : IdentityUserContext<User>
    {
        public VendingMachineContext(DbContextOptions<VendingMachineContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<IdentityRole> IdentityRoles { get; set; } = null!;
        public DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; } = null!;
        //public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Deposit> Deposits { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData.SeedUsers(modelBuilder);
            SeedData.SeedRoles(modelBuilder);
            SeedData.SeedUserRoles(modelBuilder);

            //modelBuilder.Entity<IdentityRole>().HasData(
            //        new IdentityRole() { Name = "ADMIN", NormalizedName = "ADMIN" },
            //        new IdentityRole() { Name = "BUYER", NormalizedName = "BUYER" },
            //        new IdentityRole() { Name = "SELLER", NormalizedName = "SELLER" }
            //    );

            //modelBuilder.Entity<IdentityUserRole<string>>().HasKey(
            //        x => new { x.UserId, x.RoleId }
            //    );
        }
    }
}
