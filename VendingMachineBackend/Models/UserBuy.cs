namespace VendingMachineBackend.Models
{
    public class UserBuy
    {
        public int Id { get; set; }
        public decimal PriceBoughtAt { get; set; }
        public int Amount { get; set; }
        public DateTime BuyDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
