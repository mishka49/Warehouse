using Microsoft.AspNetCore.Mvc;
using WarehouseApp.Models;
using WarehouseApp.Services.ProductService;

namespace WarehouseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IProductService _productService;
        public ProductsController(ILogger<DepartmentsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetWorkers()
        {
            return await _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Worker>>> GetSingleWorker(int id)
        {
            var result = await _productService.GetProduct(id);

            if (result is null)
                return NotFound("Sorry, worker is doesn't exist");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Worker>> AddWorker(Product product)
        {
            var result = await _productService.AddProduct(product);

            if (result is null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Worker>> UpdateWorkers(int id, Product product)
        {
            var result = await _productService.UpdateProduct(id, product);

            if (result is null)
                return NotFound("Sorry, worker is doesn't exist");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Worker>> DeleteWorkers(int id)
        {
            var result = await _productService.DeleteProduct(id);

            if (result is null)
                return NotFound("Sorry, departments is doesn't exist");

            return Ok(result);
        }
    }
}
