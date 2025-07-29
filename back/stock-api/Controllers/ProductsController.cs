using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stock_api.Models;
using stock_api.Models.Dto;
using stock_api.Services.Interface;
using System.Threading.Tasks;

namespace stock_api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductServices _services;

        public ProductsController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> getProductAll()
        {
            var data = await _services.GetProductAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getProductById(int id)
        {
            var data = await _services.GetProductById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> addProduct([FromBody] ProductDto data)
        {
            var product = await _services.AddProduct(data);
            return Ok(product);
        }

        [HttpPost("check")]
        public async Task<IActionResult> checkProduct([FromBody] ProductCheckDto data)
        {
            var result = await _services.CheckProduct(data);
            return Ok(result);
        } 
    }
}
