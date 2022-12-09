using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VendingMachineBackend.Models
{
    public class Deposit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
