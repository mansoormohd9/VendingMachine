using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VendingMachineBackend.Models.Configrations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(i => i.Name).IsUnique();

            builder.Property(e => e.Cost).HasColumnType("decimal(18, 6)");

            builder.HasOne(d => d.Seller)
                .WithMany(s => s.Products)
                .HasForeignKey(d => d.SellerId);
        }
    }
}
