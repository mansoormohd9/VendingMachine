using AutoMapper;
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
        private readonly IMapper _mapper;

        public AccountService(UserManager<User> userMgr, IJwtService jwtService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _userManager = userMgr;
            _jwtService = jwtService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<Result<string>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if(user == null)
            {
                return new Result<string>(false, "User doesn't exist");
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if(!isValidPassword)
            {
                return new Result<string>(false, "Password doesn't match");
            }

            var token = _jwtService.GenerateJwtToken();

            _httpContextAccessor.HttpContext.Session.SetString("AppUser", JsonConvert.SerializeObject(user));

            return new Result<string>(true, string.Empty, token);
        }

        public async Task<Result<string>> SignUp(SingUpDto singUpDto)
        {
            var user = await _userManager.FindByEmailAsync(singUpDto.Email);

            if (user != null)
            {
                return new Result<string>(false, "User already exists");
            }

            var newUser = _mapper.Map<User>(singUpDto);
            var result = await _userManager.CreateAsync(newUser, singUpDto.Password);
            if (!result.Succeeded)
            {
                return new Result<string>(false, string.Join(',', result.Errors, string.Empty));
            }

            var token = _jwtService.GenerateJwtToken();

            _httpContextAccessor.HttpContext.Session.SetString("AppUser", JsonConvert.SerializeObject(user));

            return new Result<string>(true, string.Empty, token);
        }
    }
}
