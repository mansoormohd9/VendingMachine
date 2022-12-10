using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingMachineBackend.Helpers;
using VendingMachineBackend.Models;
using VendingMachineBackend.Services;

namespace VendingMachineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepositsController : ControllerBase
    {
        private readonly ILogger<DepositsController> _logger;
        private readonly IDepositService _depositService;

        public DepositsController(IDepositService depositService, ILogger<DepositsController> logger)
        {
            _depositService = depositService;
            _logger = logger;
        }

        // POST: api/Deposits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("deposit")]
        public async Task<ActionResult<decimal>> PostDeposit(decimal deposit)
        {
            try
            {
                var au = HttpContext.GetCurrentAppUser();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Products Controller {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetDeposit()
        {
            try
            {
                var au = HttpContext.GetCurrentAppUser();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Products Controller {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
