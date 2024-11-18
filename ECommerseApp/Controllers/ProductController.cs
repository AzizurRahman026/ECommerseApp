using Core.Interface;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse_App.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductController : ControllerBase
    // public class ProductController (IGenericRepository<Product> _repo) : ControllerBase
    {
        private readonly IGenericRepository<Product> repo;

        public ProductController(IGenericRepository<Product> _repo)
        {
            repo = _repo;
        }

        [HttpGet("")]
        public IActionResult Root()
        {
            return Ok("Root Page...");
        }

        [HttpGet("products")]
        public async Task<ActionResult<List<Product>>> GetProducts(string? brand, string? type, string? sort)
        {
            var res = await repo.ListAllAsync();
            return Ok(res);
            /*var products = await repo.GetProducts(brand, type, sort);
            return Ok(products);*/
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {

            var product = await repo.GetByIdAsync(id);
            if (product == null)
                return NotFound($"No product found with ID: {id}");

            return Ok(product);

            /*var product = await repo.GetProductById(id);
            return Product;*/
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            // implement code...
            return Ok();

            /*var brands = await repo.GetBrands();
            return Ok(brands);*/
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            // implement code...
            return Ok();

            /*var types = await repo.GetTypes();
            return Ok(types);*/
        }

        [HttpPost("addproducts")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            try
            {
                await repo.Add(product);
                return Ok("Product Add Successful!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            /*var result = await repo.AddProduct(product);
            if (result == "Added Product...")
                return Ok(result);

            return BadRequest(result);*/
        }

        [HttpPut("products/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            try
            {
                bool exist = await repo.Exist(id);
                Console.WriteLine("IsExist: " + exist);
                if (exist == false)
                {
                    return NotFound($"Not found with ID: {id}");
                }
                await repo.Update(product);
                return Ok("Update product successful!");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update product");
            }
            /*var exists = await repo.ExistProduct(id);
            if (!exists)
                return NotFound($"No product found with ID: {id}");

            var result = await repo.UpdateProduct(id, product);
            if (result == 1)
                return Ok("Product updated successfully.");

            return BadRequest("Failed to update the product.");*/
            
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await repo.Remove(id);
                return Ok("Remove Product Successful!");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete the product.");
            }

            /*var exists = await repo.ExistProduct(id);
            if (!exists)
                return NotFound($"No product found with ID: {id}");

            var result = await repo.DeleteProduct(id);
            if (result)
                return Ok("Product deleted successfully.");

            return BadRequest("Failed to delete the product.");*/
        }
    }
}
