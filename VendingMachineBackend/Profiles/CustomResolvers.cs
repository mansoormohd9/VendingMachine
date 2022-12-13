using AutoMapper;
using Microsoft.AspNetCore.Identity;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Helpers;
using VendingMachineBackend.Models;
using VendingMachineBackend.Repositories;

namespace VendingMachineBackend.Profiles
{
    public static class CustomResolvers
    {
        public class SellerIdResolver : IValueResolver<ProductDto, Product, string>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;


            public SellerIdResolver(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public string Resolve(ProductDto source, Product target, string sellerId, ResolutionContext context)
            {
                var appUser = _httpContextAccessor.HttpContext.GetCurrentAppUser();
                return appUser.Id;
            }
        }

        public class SellerIdSaveResolver : IValueResolver<ProductSaveDto, Product, string>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;


            public SellerIdSaveResolver(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public string Resolve(ProductSaveDto source, Product target, string sellerId, ResolutionContext context)
            {
                var appUser = _httpContextAccessor.HttpContext.GetCurrentAppUser();
                return appUser.Id;
            }
        }

        public class BuyerIdResolver : IValueResolver<DepositDto, UserDeposit, string>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;


            public BuyerIdResolver(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public string Resolve(DepositDto source, UserDeposit target, string sellerId, ResolutionContext context)
            {
                var appUser = _httpContextAccessor.HttpContext.GetCurrentAppUser();
                return appUser.Id;
            }
        }

        public class DepositIdResolver : IValueResolver<DepositDto, UserDeposit, int>
        {
            private readonly IDepositRepository _depositRepository;


            public DepositIdResolver(IDepositRepository depositRepository)
            {
                _depositRepository = depositRepository;
            }

            public int Resolve(DepositDto source, UserDeposit target, int sellerId, ResolutionContext context)
            {
                var deposit = _depositRepository.SingleOrDefault(x => x.Amount == source.Deposit);
                return deposit.Id;
            }
        }

        public class DepositAmountResolver : IValueResolver<UserDeposit, DepositDto, decimal>
        {
            private readonly IDepositRepository _depositRepository;


            public DepositAmountResolver(IDepositRepository depositRepository)
            {
                _depositRepository = depositRepository;
            }

            public decimal Resolve(UserDeposit source, DepositDto target, decimal amount, ResolutionContext context)
            {
                var deposit = _depositRepository.SingleOrDefault(x => x.Id == source.DepositId);
                return deposit.Amount;
            }
        }

        public class UserRolesResolver : IValueResolver<User, UserDto, IList<string>>
        {
            private readonly UserManager<User> _userManager;

            public UserRolesResolver(UserManager<User> userManager)
            {
                _userManager = userManager;
            }

            public IList<string> Resolve(User source, UserDto target, IList<string> userRoles, ResolutionContext context)
            {
                var appUser = Task.Run(async () => await _userManager.FindByEmailAsync(source.Email)).Result;
                if(appUser == null)
                {
                    return new List<string>();
                }
                var roles = Task.Run(async () => await _userManager.GetRolesAsync(appUser)).Result;
                return roles ?? new List<string>();
            }
        }

        public class ProductPriceResolver : IValueResolver<BuyDto, UserBuy, decimal>
        {
            private readonly IProductRepository _productRepository;


            public ProductPriceResolver(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public decimal Resolve(BuyDto source, UserBuy target, decimal sellerId, ResolutionContext context)
            {
                var product = _productRepository.SingleOrDefault(x => x.Id == source.ProductId);
                return product.Cost;
            }
        }

        public class UserBuyUserResolver : IValueResolver<BuyDto, UserBuy, string>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public UserBuyUserResolver(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public string Resolve(BuyDto source, UserBuy target, string sellerId, ResolutionContext context)
            {
                var appUser = _httpContextAccessor.HttpContext.GetCurrentAppUser();
                return appUser.Id;
            }
        }
    }
}
