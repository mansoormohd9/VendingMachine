using AutoMapper;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;
using VendingMachineBackend.Repositories;

namespace VendingMachineBackend.Services
{
    public class DepositService : IDepositService
    {
        private readonly IDepositRepository _depositRepository;
        private readonly IUserDepositRepository _userDepositRepository;
        private readonly IMapper _mapper;
        public DepositService(IDepositRepository depositRepository, IUserDepositRepository userDepositRepository, IMapper mapper)
        {
            _depositRepository = depositRepository;
            _userDepositRepository = userDepositRepository;
            _mapper = mapper;
        }

        public IEnumerable<DepositDto> GetDeposits(User au)
        {
            var deposits = _userDepositRepository.Find(x => x.UserId == au.Id).ToList();

            return deposits.Select(x => _mapper.Map<DepositDto>(x));
        }

        public async Task<Result<string>> PostDeposit(List<DepositDto> depositDtos)
        {
            var deposits = depositDtos.Select(x => x.Deposit);

            if (HasInvalidDeposits(deposits))
            {
                return new Result<string>(false, "Invalid Deposits found");
            }

            var userDeposits = depositDtos.Select(x => _mapper.Map<UserDeposit>(x));
            await _userDepositRepository.AddRangeAsync(userDeposits);

            return new Result<string>(true, "Deposit Success");
        }

        public async Task ResetDeposit(User au)
        {
            var deposits = _userDepositRepository.Find(x => x.UserId == au.Id).ToList();

            await _userDepositRepository.RemoveRangeAsync(deposits);
        }

        private bool HasInvalidDeposits(IEnumerable<decimal> deposits)
        {
            var validDeposits = _depositRepository.GetAll().Select(x => x.Amount).ToHashSet();

            return deposits.Where(x => !validDeposits.Contains(x)).Any();
        }
    }
}
