namespace ProductShop.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShop.Models;

    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Price)
                .IsRequired();

            builder
                .HasOne(x => x.Seller)
                .WithMany(x => x.ProductsSold)
                .HasForeignKey(x => x.SellerId)
                .IsRequired();

            builder
                .HasOne(x => x.Buyer)
                .WithMany(x => x.ProductsBought)
                .HasForeignKey(x => x.BuyerId);
        }
    }
}
