using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Services;

namespace VendingMachineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetAll());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(string id)
        {
            try
            {
                var userResult = _userService.GetUserById(id);

                if (!userResult.Success)
                {
                    return BadRequest(userResult.Message);
                }

                return Ok(userResult.Value);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error in UserController {ex.Message}");
                return StatusCode(500);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] UserDto userDto)
        {
            try
            {
                var userResult = await _userService.AddAsync(userDto);

                if (!userResult.Success)
                {
                    return BadRequest(userResult.Message);
                }

                return Ok(userResult.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UserController {ex.Message}");
                return StatusCode(500);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UserDto userDto)
        {
            try
            {
                var userResult = await _userService.UpdateAsync(id, userDto);

                if (!userResult.Success)
                {
                    return BadRequest(userResult.Message);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UserController {ex.Message}");
                return StatusCode(500);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var userResult = await _userService.DeleteAsync(id);

                if (!userResult.Success)
                {
                    return BadRequest(userResult.Message);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UserController {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
