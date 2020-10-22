using Microsoft.EntityFrameworkCore;
using Store.Entity.Domains;
using Store.Entity.Extentions;
using System;

namespace Store.Entity
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Seed();
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchType> BranchTypes { get; set; }
        public DbSet<ProductBranch> ProductBranches { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
    }
}
