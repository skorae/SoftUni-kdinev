namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;
    using ProductShop.Data.Configuration;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-L5A0R6C\SQLEXPRESS;Database=ProductShop;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryProductEntityConfiguration());
        }
    }
}