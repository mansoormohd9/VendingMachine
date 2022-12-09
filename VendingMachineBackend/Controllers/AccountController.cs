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

            if(!loginResult.Success)
            {
                return BadRequest(loginResult.Message);
            }

            return Ok(loginResult.Value);
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SingUpDto singUpDto)
        {
            var signUpResult = await _accountService.SignUp(singUpDto);

            if (!signUpResult.Success)
            {
                return BadRequest(signUpResult.Message);
            }

            return Ok(signUpResult.Value);
        }

        [HttpGet("logOut")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Ok();
        }
    }
}
