using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VendingMachineBackend.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int AmountAvailable { get; set; }
        public decimal Cost { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string SellerId { get; set; }

        public virtual User Seller { get; set; }
        public virtual ICollection<UserBuy> UserBuys { get; set; }

        public Product()
        {
            UserBuys = new HashSet<UserBuy>();
        }
    }
}
