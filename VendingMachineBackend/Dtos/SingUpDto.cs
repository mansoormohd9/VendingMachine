using System.ComponentModel.DataAnnotations;

namespace VendingMachineBackend.Dtos
{
    public class SingUpDto: LoginDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("Buyer|Seller", ErrorMessage = "Invalid Role")]
        public string Role { get; set; }
    }
}
