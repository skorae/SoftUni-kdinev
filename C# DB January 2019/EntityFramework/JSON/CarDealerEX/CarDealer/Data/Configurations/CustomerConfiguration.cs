namespace CarDealer.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Models;

    public class CustomerConfiguration
    {
        public void CustomerEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasKey(c => c.Id);

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.BirthDate)
                .IsRequired();

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.IsYoungDriver)
                .IsRequired();

        }
    }
}
