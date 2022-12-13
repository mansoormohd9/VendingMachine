namespace VendingMachineBackend.Dtos
{
    public class UserBuyDto
    {
        public string Product { get; set; }
        public decimal PriceBoughtAt { get; set; }
        public int Amount { get; set; }
        public DateTime BuyDate { get; set; }
    }
}
