using Microsoft.AspNetCore.Identity;

namespace VendingMachineBackend.Models
{
    public class Deposit
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}
