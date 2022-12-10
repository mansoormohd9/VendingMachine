namespace VendingMachineBackend.Models
{
    public class UserBuy
    {
        public int Id { get; set; }
        public decimal PriceBoughtAt { get; set; }
        public int Amount { get; set; }
        public int BuyDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
