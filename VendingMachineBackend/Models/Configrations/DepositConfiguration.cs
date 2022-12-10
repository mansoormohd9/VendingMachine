using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VendingMachineBackend.Models.Configrations
{
    public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            builder.HasIndex(i => i.Amount).IsUnique();

            builder.Property(e => e.Amount).HasColumnType("decimal(18, 6)");
        }
    }
}
