namespace P03_SalesDatabase.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Product(modelBuilder);

            Customer(modelBuilder);

            Store(modelBuilder);

            Sale(modelBuilder);
        }

        private void Sale(ModelBuilder modelBuilder)
        {
            modelBuilder
              .Entity<Sale>()
              .HasKey(c => c.SaleId);

            modelBuilder
                .Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");
        }

        private void Store(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Store>()
               .HasKey(c => c.StoreId);
            
            modelBuilder
              .Entity<Store>()
              .Property(c => c.Name)
              .HasMaxLength(80)
              .IsUnicode();

            modelBuilder
                .Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Store);
        }

        private void Customer(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasKey(c => c.CustomerId);
            
            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80);

            modelBuilder
                .Entity<Customer>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Customer);
        }

        private void Product(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasKey(p => p.ProductId);
            
            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");

            modelBuilder
                .Entity<Product>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Product);
        }
    }
}
