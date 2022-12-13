using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VendingMachineBackend.Models.Configrations
{
    public class UserBuyConfiguration : IEntityTypeConfiguration<UserBuy>
    {
        public void Configure(EntityTypeBuilder<UserBuy> builder)
        {
            builder.Property(e => e.PriceBoughtAt).HasColumnType("decimal(18, 6)");

            builder.HasOne(d => d.Product)
                .WithMany(s => s.UserBuys)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(d => d.User)
                .WithMany(s => s.UserBuys)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
