using System.ComponentModel.DataAnnotations;

namespace VendingMachineBackend.Dtos
{
    public class DepositDto
    {
        [Required]
        public decimal Deposit { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
