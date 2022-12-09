using Microsoft.AspNetCore.Identity;

namespace VendingMachineBackend.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<Product> Products { get; set; }        

        public User()
        {
            Products = new HashSet<Product>();
        }
    }
}
