namespace CarDealer.Data
{
    using CarDealer.Models;
    using CarDealer.Data.Configurations;
    using Microsoft.EntityFrameworkCore;

    public class CarDealerContext : DbContext
    {
        public CarDealerContext(DbContextOptions options)
            : base(options)
        {
        }

        public CarDealerContext()
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<PartCar> PartCars { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-L5A0R6C\SQLEXPRESS;Database=CarDealer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CarEntityConfiguraion(modelBuilder);

            CustomerEntityConfiguraion(modelBuilder);

            PartsEntityConfiguraion(modelBuilder);

            PartCarsEntityConfiguraion(modelBuilder);

            SalesEntityConfiguraion(modelBuilder);

            SuppliersEntityConfiguraion(modelBuilder);
        }

        private void SuppliersEntityConfiguraion(ModelBuilder modelBuilder)
        {
            var config = new SupplierConfiguration();
            config.SupplierEntityConfiguration(modelBuilder);
        }

        private void SalesEntityConfiguraion(ModelBuilder modelBuilder)
        {
            var config = new SaleConfiguration();
            config.SaleEntityConfiguration(modelBuilder);
        }

        private void PartCarsEntityConfiguraion(ModelBuilder modelBuilder)
        {
            var config = new PartCarsConfiguration();
            config.ParsCarsEntityConfiguration(modelBuilder);
        }

        private void PartsEntityConfiguraion(ModelBuilder modelBuilder)
        {
            var config = new PartsConfiguraition();
            config.PartsEntityConfiguration(modelBuilder);
        }

        private void CustomerEntityConfiguraion(ModelBuilder modelBuilder)
        {
            var config = new CustomerConfiguration();
            config.CustomerEntityConfiguration(modelBuilder);
        }

        private void CarEntityConfiguraion(ModelBuilder modelBuilder)
        {
            var config = new CarConfiguration();
            config.CarEntityConfiguration(modelBuilder);
        }
    }
}
