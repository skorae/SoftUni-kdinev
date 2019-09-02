namespace CarDealer.Data.Configurations
{
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;

    public class CarConfiguration
    {
        public void CarEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Car>()
                .HasKey(c => c.Id);

            modelBuilder
                .Entity<Car>()
                .Property(m => m.Make)
                .IsRequired();

            modelBuilder
               .Entity<Car>()
               .Property(m => m.Model)
               .IsRequired();

            modelBuilder
               .Entity<Car>()
               .Property(m => m.TravelledDistance)
               .IsRequired();
            
        }
    }
}
