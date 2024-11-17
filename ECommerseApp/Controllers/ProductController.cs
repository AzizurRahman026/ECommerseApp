using Core.Interface;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse_App.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository repo;

        public HomeController(IProductRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet("")]
        public IActionResult Root()
        {
            return Ok(repo.Root());
        }

        [HttpGet("products")]
        public async Task<ActionResult<List<Product>>> GetProducts(string? brand, string? type, string? sort)
        {
            var products = await repo.GetProducts(brand, type, sort);
            return Ok(products);
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await repo.GetProductById(id);
            if (product == null)
                return NotFound($"No product found with ID: {id}");

            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await repo.GetBrands();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            var types = await repo.GetTypes();
            return Ok(types);
        }

        [HttpPost("addproducts")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var result = await repo.AddProduct(product);
            if (result == "Added Product...")
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("products/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            var exists = await repo.ExistProduct(id);
            if (!exists)
                return NotFound($"No product found with ID: {id}");

            var result = await repo.UpdateProduct(id, product);
            if (result == 1)
                return Ok("Product updated successfully.");

            return BadRequest("Failed to update the product.");
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var exists = await repo.ExistProduct(id);
            if (!exists)
                return NotFound($"No product found with ID: {id}");

            var result = await repo.DeleteProduct(id);
            if (result)
                return Ok("Product deleted successfully.");

            return BadRequest("Failed to delete the product.");
        }
    }
}
