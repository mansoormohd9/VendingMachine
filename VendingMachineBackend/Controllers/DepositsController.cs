using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Helpers;
using VendingMachineBackend.Services;

namespace VendingMachineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,BUYER")]
    public class DepositsController : ControllerBase
    {
        private readonly ILogger<DepositsController> _logger;
        private readonly IDepositService _depositService;

        public DepositsController(IDepositService depositService, ILogger<DepositsController> logger)
        {
            _depositService = depositService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DepositDto>> GetDeposits()
        {
            var au = HttpContext.GetCurrentAppUser();
            var deposits = _depositService.GetDeposits(au);
            return Ok(deposits);
        }

        // POST: api/Deposits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDeposit([FromBody] List<DepositDto> depositDtos)
        {
            try
            {
                var au = HttpContext.GetCurrentAppUser();
                var depositResult = await _depositService.PostDeposit(depositDtos);

                if (!depositResult.Success)
                {
                    return BadRequest(depositResult.Message);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DepositsController {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetDeposit()
        {
            try
            {
                var au = HttpContext.GetCurrentAppUser();
                await _depositService.ResetDeposit(au);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DepositsController {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
