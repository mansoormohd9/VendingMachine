using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VendingMachineBackend.Models.Configrations
{
    public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            builder.HasData(
                new Deposit[]
                {
                    new Deposit{ Id = 1, Amount = 5 },
                    new Deposit{ Id = 2, Amount = 10 },
                    new Deposit{ Id = 3, Amount = 20 },
                    new Deposit{ Id = 4, Amount = 50 },
                    new Deposit{ Id = 5, Amount = 100 },
                });

            builder.HasIndex(i => i.Amount).IsUnique();

            builder.Property(e => e.Amount).HasColumnType("decimal(18, 6)");
        }
    }
}
