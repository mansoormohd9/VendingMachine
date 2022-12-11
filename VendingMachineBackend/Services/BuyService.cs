using AutoMapper;
using System.Linq;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;
using VendingMachineBackend.Repositories;

namespace VendingMachineBackend.Services
{
    public class BuyService : IBuyService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserDepositRepository _userDepositRepository;
        private readonly IDepositRepository _depositRepository;
        private readonly IUserBuyRepository _userBuyRepository;
        private readonly IMapper _mapper;

        public BuyService(IUserDepositRepository userDepositRepository, IProductRepository productRepository, IDepositRepository depositRepository, IMapper mapper, IUserBuyRepository userBuyRepository)
        {
            _productRepository = productRepository;
            _userDepositRepository = userDepositRepository;
            _depositRepository = depositRepository;
            _mapper = mapper;
            _userBuyRepository = userBuyRepository;
        }

        public async Task<Result<List<DepositDto>>> PlaceBuyOrderAsync(BuyDto buyDto, User au)
        {
            var canBuyResult = CanBuy(buyDto, au);

            if (!canBuyResult.Success)
            {
                return new Result<List<DepositDto>>(canBuyResult.Success, canBuyResult.Message);
            }

            var toBeUpdatedDeposits = _userDepositRepository.Find(x => x.UserId == au.Id).ToList();
            var depoistAmountMap = _depositRepository.Find(x => canBuyResult.Value.ContainsKey(x.Amount)).ToDictionary(x => x.Id, x => x.Amount);
            foreach (var deposit in toBeUpdatedDeposits)
            {
                if (depoistAmountMap.ContainsKey(deposit.DepositId) && canBuyResult.Value.ContainsKey(depoistAmountMap[deposit.DepositId]))
                {
                    deposit.Quantity = canBuyResult.Value[depoistAmountMap[deposit.DepositId]];
                }
            }

            //update user deposits
            await _userDepositRepository.UpdateRangeAsync(toBeUpdatedDeposits);

            //add userBuy record
            var userBuy = _mapper.Map<UserBuy>(buyDto);
            await _userBuyRepository.AddAsync(userBuy);

            var userReturn = toBeUpdatedDeposits.Select(x => _mapper.Map<DepositDto>(x)).ToList();

            return new Result<List<DepositDto>>(true, "Buy placed", userReturn);
        }

        public Result<Dictionary<decimal, int>> CanBuy(BuyDto buyDto, User au)
        {
            var product = _productRepository.SingleOrDefault(x => x.Id == buyDto.ProductId);

            if (product == null)
            {
                return new Result<Dictionary<decimal, int>>(false, "Product doesn't exist");
            }

            if (product.AmountAvailable < buyDto.Amount)
            {
                return new Result<Dictionary<decimal, int>>(false, "Quantity not available");
            }

            var totalAmount = product.Cost * buyDto.Amount;

            var userDeposits = _userDepositRepository.Find(x => x.UserId == au.Id).ToDictionary(x => x.DepositId, v => v.Quantity);
            var depoistAmountMap = _depositRepository.Find(x => userDeposits.ContainsKey(x.Id)).ToDictionary(x => x.Id, x => x.Amount);

            var amountsAvailable = userDeposits.Keys.OrderByDescending(x => x).ToHashSet();

            //TODO fix below logic to handle all cases
            var totalPriceNeeded = totalAmount;
            foreach (var amount in amountsAvailable)
            {
                var requiredQuantity = (int)(totalPriceNeeded / amount);

                var availableQuantity = Math.Min(requiredQuantity, userDeposits[amount]);

                totalPriceNeeded = totalPriceNeeded - amount * availableQuantity;

                //updating quantities
                userDeposits[amount] = userDeposits[amount] - availableQuantity;

                if (totalPriceNeeded <= 0)
                {
                    break;
                }
            }

            if (totalPriceNeeded > 0)
            {
                return new Result<Dictionary<decimal, int>>(false, "Please retry with new deposits");
            }

            return new Result<Dictionary<decimal, int>>(true, string.Empty, userDeposits);
        }
    }
}
