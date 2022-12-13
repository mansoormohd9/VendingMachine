using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Helpers;
using VendingMachineBackend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendingMachineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,BUYER")]
    public class BuyController : ControllerBase
    {
        private readonly ILogger<BuyController> _logger;
        private readonly IBuyService _buyService;
        public BuyController(IBuyService buyService, ILogger<BuyController> logger)
        {
            _buyService = buyService;
            _logger = logger;
        }

        [HttpPost("canBuy")]
        public ActionResult<string> CanBuy([FromBody] BuyDto buyDto)
        {
            try
            {
                var au = HttpContext.GetCurrentAppUser();
                var depositResult = _buyService.CanBuy(buyDto, au);

                if (!depositResult.Success)
                {
                    return BadRequest(depositResult.Message);
                }

                return Ok(depositResult.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in BuyController {ex.Message}");
                return StatusCode(500);
            }
        }

        // POST api/<BuyController>
        [HttpPost]
        public async Task<ActionResult<List<DepositDto>>> Post([FromBody] BuyDto buyDto)
        {
            try
            {
                var au = HttpContext.GetCurrentAppUser();
                var depositResult = await _buyService.PlaceBuyOrderAsync(buyDto, au);

                if (!depositResult.Success)
                {
                    return BadRequest(depositResult.Message);
                }

                return Ok(depositResult.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in BuyController {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
