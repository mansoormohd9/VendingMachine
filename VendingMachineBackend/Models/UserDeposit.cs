using System.ComponentModel.DataAnnotations;

namespace VendingMachineBackend.Models
{
    public class UserDeposit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DepositId { get; set; }
        public virtual Deposit Deposit { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
