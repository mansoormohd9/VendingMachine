using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;

namespace VendingMachineBackend.Services
{
    public interface IBuyService
    {
        Result<Dictionary<decimal, int>> CanBuy(BuyDto buyDto, User au);
        Task<Result<List<DepositDto>>> PlaceBuyOrderAsync(BuyDto buyDto, User au);
    }
}