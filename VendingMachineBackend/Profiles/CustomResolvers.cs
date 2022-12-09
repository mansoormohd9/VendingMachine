using AutoMapper;
using Microsoft.AspNetCore.Identity;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Helpers;
using VendingMachineBackend.Models;

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
    }
}
