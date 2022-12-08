using Microsoft.AspNetCore.Identity;

namespace VendingMachineBackend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid SellerId { get; set; }

        public IdentityUser Seller { get; set; }
    }
}
