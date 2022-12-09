using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingMachineBackend.Dtos;
using VendingMachineBackend.Helpers;
using VendingMachineBackend.Models;
using VendingMachineBackend.Services;

namespace VendingMachineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                return Ok(_productService.GetAll());
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error in Products Controller {ex.Message}");
                return StatusCode(500);
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var productResult = await _productService.Get(id);

                if (!productResult.Success)
                {
                    return BadRequest(productResult.Message);
                }

                return Ok(productResult.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Products Controller {ex.Message}");
                return StatusCode(500);
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductSaveDto product)
        {
            try
            {
                var au = HttpContext.GetCurrentAppUser();
                var productResult = await _productService.UpdateAsync(id, product, au);

                if (!productResult.Success)
                {
                    return BadRequest(productResult.Message);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Products Controller {ex.Message}");
                return StatusCode(500);
            }
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductSaveDto product)
        {
            try
            {
                var productResult = await _productService.AddAsync(product);

                if (!productResult.Success)
                {
                    return BadRequest(productResult.Message);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Products Controller {ex.Message}");
                return StatusCode(500);
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var au = HttpContext.GetCurrentAppUser();
                var productResult = await _productService.DeleteAsync(id, au);

                if (!productResult.Success)
                {
                    return BadRequest(productResult.Message);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Products Controller {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
