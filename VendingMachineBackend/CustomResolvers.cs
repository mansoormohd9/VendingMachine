using AutoMapper;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Helpers;
using VendingMachineBackend.Models;

namespace VendingMachineBackend
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
    }
}
