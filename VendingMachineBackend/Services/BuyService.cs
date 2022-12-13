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

            var coinsAvailable = depoistAmountMap.Values.Select(x => (int)x).ToArray();
            var limits = depoistAmountMap.Select(x => userDeposits[x.Key]).ToArray();

            var coinChange = CoinChangeWithMemoization(coinsAvailable, limits, (int)totalAmount);

            if(coinChange.minCount == -1)
            {
                return new Result<Dictionary<decimal, int>>(false, "Please retry with new deposits");
            }
            var updatedQuantiyMap = coinsAvailable.Select((x, i) => new { Amount = x, Quantity = limits[i] }).ToDictionary(x => (decimal)x.Amount, x => x.Quantity);
            return new Result<Dictionary<decimal, int>>(true, string.Empty, updatedQuantiyMap);
        }

        public (int minCount, int[] arr) CoinChangeWithMemoization(int[] coins, int[] limits, int amount)
        {
            int[,] t = new int[coins.Length, amount + 1];

            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = 0; j < amount + 1; j++)
                {
                    t[i, j] = -1;
                }
            }

            var result = SolveCoinChange(coins, limits, coins.Length - 1, t, amount);

            if (result.minCount == int.MaxValue - 1)
            {
                return (-1, result.arr);
            }

            return (result.minCount, result.arr);
        }


        public (int minCount, int[] arr) SolveCoinChange(int[] coins, int[] limits, int n, int[,] t, int amount)
        {
            if (n < 0)
            {
                return (-1, limits);
            }

            if (amount == 0)
            {
                return (0, limits);
            }

            if (n == 0 && amount > 0)
            {
                var requiredQuantity = amount / coins[n];
                if ((amount % coins[n] == 0) && limits[n] >= requiredQuantity)
                {
                    limits[n] = limits[n] - requiredQuantity;
                    return (requiredQuantity, limits);
                }
                else
                {
                    return (int.MaxValue - 1, limits);
                }
            }

            if (t[n, amount] != -1)
            {
                return (t[n, amount], limits);
            }

            (int minCount, int[] arr) result;
            if (limits[n] == 0)
            {
                result = SolveCoinChange(coins, limits, n - 1, t, amount);
                t[n, amount] = result.minCount;
                return result;
            }

            if (coins[n] <= amount)
            {
                var temp = new int[coins.Length];
                Array.Copy(limits, temp, coins.Length);

                temp[n]--;
                var result1 = 1 + SolveCoinChange(coins, temp, n, t, amount - coins[n]).minCount;
                var result2 = SolveCoinChange(coins, limits, n - 1, t, amount).minCount;


                if (result1 < result2)
                {
                    Array.Copy(temp, limits, coins.Length);
                    t[n, amount] = result1;
                    return (result1, limits);
                }
                return (result2, limits);
            }

            t[n, amount] = SolveCoinChange(coins, limits, n - 1, t, amount).minCount;
            return (t[n, amount], limits);
        }
    }
}
