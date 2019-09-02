namespace CarDealer.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Models;

    public class SaleConfiguration
    {
        public void SaleEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sale>()
                .HasKey(s => s.Id);

            modelBuilder
                .Entity<Sale>()
                .Property(s => s.Discount)
                .IsRequired();

            modelBuilder
                .Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(fk => fk.CustomerId);

            modelBuilder
                .Entity<Sale>()
                .HasOne(s => s.Car)
                .WithMany(c => c.Sales)
                .HasForeignKey(fk => fk.CarId);
        }
    }
}
