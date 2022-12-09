using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Models;

namespace VendingMachineBackend.Services
{
    public class AccountService: IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(UserManager<User> userMgr, IJwtService jwtService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userMgr;
            _jwtService = jwtService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(Result result, string token)> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if(user == null)
            {
                return (new Result(false, "User doesn't exist"), string.Empty);
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if(!isValidPassword)
            {
                return (new Result(false, "Password doesn't match"), string.Empty);
            }

            var token = _jwtService.GenerateJwtToken();

            _httpContextAccessor.HttpContext.Session.SetString("AppUser", JsonConvert.SerializeObject(user));

            return (new Result(true, string.Empty), token);
        }

        public async Task<(Result result, string token)> SignUp(SingUpDto singUpDto)
        {
            var user = await _userManager.FindByEmailAsync(singUpDto.Email);

            if (user != null)
            {
                return (new Result(false, "User already exists"), string.Empty);
            }

            var newUser = new User
            {
                UserName = singUpDto.Email,
                Email = singUpDto.Email,
                FirstName  = singUpDto.FirstName,
                LastName = singUpDto.LastName
            };
            var result = await _userManager.CreateAsync(newUser, singUpDto.Password);
            if (!result.Succeeded)
            {
                return (new Result(false, string.Join(',', result.Errors)), string.Empty);
            }

            var token = _jwtService.GenerateJwtToken();

            _httpContextAccessor.HttpContext.Session.SetString("AppUser", JsonConvert.SerializeObject(user));

            return (new Result(true, string.Empty), token);
        }
    }
}
