using Microsoft.AspNetCore.Mvc;
using ExamenBazar.Services;

namespace ExamenBazar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult SearchProducts([FromQuery] string q)
        {
            var results = _productService.SearchProducts(q ?? "");
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound(new { error = "Product not found" });
            }
            return Ok(product);
        }
    }
}
