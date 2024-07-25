using Microsoft.AspNetCore.Mvc;
using WebApplication1.IService;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControllerApi : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsControllerApi(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null || product.Id != id)
            {
                return BadRequest();
            }

            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpGet("categories")]
        public IActionResult GetAllCategories()
        {
            var categories = _productService.GetAllCategories();
            return Ok(categories);
        }
    }
}
