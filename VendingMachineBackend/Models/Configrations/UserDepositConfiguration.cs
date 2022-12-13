using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VendingMachineBackend.Models.Configrations
{
    public class UserDepositConfiguration : IEntityTypeConfiguration<UserDeposit>
    {
        public void Configure(EntityTypeBuilder<UserDeposit> builder)
        {
            builder.HasIndex(x => new { x.UserId, x.DepositId }).IsUnique();
        }
    }
}
