using System.ComponentModel.DataAnnotations;

namespace VendingMachineBackend.Dtos
{
    public class ProductSaveDto
    {
        [Required]
        public string Name { get; set; }
        public int AmountAvailable { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}
