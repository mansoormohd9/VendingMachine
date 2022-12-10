using System.ComponentModel.DataAnnotations;

namespace VendingMachineBackend.Dtos
{
    public class BuyDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
