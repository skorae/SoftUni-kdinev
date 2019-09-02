namespace CarDealer.Data.Configuration
{
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartCarEntityConfiguration : IEntityTypeConfiguration<PartCar>
    {
        public void Configure(EntityTypeBuilder<PartCar> builder)
        {
            builder
                .HasKey(x => new { x.PartId, x.CarId });

            builder
                .HasOne(x => x.Part)
                .WithMany(x => x.PartCars)
                .HasForeignKey(x => x.PartId);

            builder
               .HasOne(x => x.Car)
               .WithMany(x => x.PartCars)
               .HasForeignKey(x => x.CarId);
        }
    }
}
