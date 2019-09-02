namespace CarDealer.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Models;

    public class PartCarsConfiguration
    {
        public void ParsCarsEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PartCar>()
                .HasKey(pc => new { pc.PartId, pc.CarId });

            modelBuilder
                .Entity<PartCar>()
                .HasOne(pc => pc.Part)
                .WithMany(p => p.PartCars)
                .HasForeignKey(x => x.PartId);

            modelBuilder
               .Entity<PartCar>()
               .HasOne(pc => pc.Car)
               .WithMany(p => p.PartCars)
               .HasForeignKey(x => x.CarId);
        }
    }
}
