namespace CarDealer.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Models;

    public class SupplierConfiguration
    {
        public void SupplierEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Supplier>()
                .HasKey(s => s.Id);

            modelBuilder
               .Entity<Supplier>()
               .Property(s => s.Name)
               .IsRequired();

            modelBuilder
               .Entity<Supplier>()
               .Property(s => s.IsImporter)
               .IsRequired();
        }
    }
}
