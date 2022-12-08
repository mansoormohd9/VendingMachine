using System.ComponentModel.DataAnnotations;

namespace VendingMachineBackend.Dtos
{
    public class SingUpDto: LoginDto
    {
        [Required]
        [RegularExpression("Buyer|Seller", ErrorMessage = "Invalid Role")]
        public string Role { get; set; }
    }
}
