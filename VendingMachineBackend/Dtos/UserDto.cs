using System.ComponentModel.DataAnnotations;

namespace VendingMachineBackend.Dtos
{
    public class UserDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public IList<string> Roles { get; set; }
    }
}
