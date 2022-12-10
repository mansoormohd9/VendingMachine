using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;

namespace VendingMachineBackend.Services
{
    public interface IDepositService
    {
        IEnumerable<DepositDto> GetDeposits(User au);
        Task<Result<string>> PostDeposit(List<DepositDto> depositDtos);
        Task ResetDeposit(User au);
    }
}