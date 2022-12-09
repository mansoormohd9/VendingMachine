using System.ComponentModel.DataAnnotations;

namespace VendingMachineBackend.Dtos
{
    public class UserDto
    {
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
