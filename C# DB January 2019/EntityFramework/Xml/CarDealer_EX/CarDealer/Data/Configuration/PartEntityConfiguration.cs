
namespace CarDealer.Data.Configuration
{
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartEntityConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Supplier)
                .WithMany(x => x.Parts)
                .HasForeignKey(x => x.SupplierId);
        }
    }
}
