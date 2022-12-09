using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Services;

namespace VendingMachineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginDto login)
        {
            var loginResult = await _accountService.Login(login);

            if(!loginResult.result.Success)
            {
                return BadRequest(loginResult.result.Message);
            }

            SetJWTCookie(loginResult.token);
            return Ok(loginResult.token);
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SingUpDto singUpDto)
        {
            var signUpResult = await _accountService.SignUp(singUpDto);

            if (!signUpResult.result.Success)
            {
                return BadRequest(signUpResult.result.Message);
            }

            SetJWTCookie(signUpResult.token);
            return Ok(signUpResult.token);
        }

        [HttpGet("logOut")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Ok();
        }

        private void SetJWTCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddHours(3),
            };
            Response.Cookies.Append("jwtCookie", token, cookieOptions);
        }
    }
}
