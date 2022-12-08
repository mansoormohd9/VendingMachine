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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody]LoginDto login)
        {
            var loginResult = await _accountService.Login(login);

            if(!loginResult.result.Success)
            {
                return BadRequest(loginResult.result.Message);
            }

            return Ok(loginResult.token);
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([FromBody] SingUpDto singUpDto)
        {
            var signUpResult = await _accountService.SignUp(singUpDto);

            if (!signUpResult.result.Success)
            {
                return BadRequest(signUpResult.result.Message);
            }

            return Ok(signUpResult.token);
        }

        [HttpGet("logOut")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Ok();
        }
    }
}
