namespace CarDealer.Data.Configurations
{
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;

    public class PartsConfiguraition
    {
        public void PartsEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Part>()
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<Part>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder
                .Entity<Part>()
                .Property(x => x.Price)
                .IsRequired();

            modelBuilder
                .Entity<Part>()
                .Property(x => x.Quantity)
                .IsRequired();

            modelBuilder
                .Entity<Part>()
                .HasOne(s => s.Supplier)
                .WithMany(p => p.Parts)
                .HasForeignKey(fk => fk.SupplierId);
            
        }
    }
}
