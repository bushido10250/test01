using Microsoft.AspNetCore.Mvc;
using stock_api.Models;
using stock_api.Models.Dto;
using stock_api.Services;
using stock_api.Services.Interface;

namespace stock_api.Controllers
{
    [Route("api/sale")]
    [ApiController]
    public class SaleController : Controller
    {
        readonly private IProductServices _productServices;
        readonly private ISaleItemServices _saleItemServices;
        readonly private ISaleServices _saleServices;

        public SaleController(ISaleServices saleServices, ISaleItemServices saleItemServices, IProductServices productServices)
        {
            _saleServices = saleServices;
            _saleItemServices = saleItemServices;
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> getSaleAll()
        {
            var data = await _saleServices.GetSaleAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleBySaleId(int id)
        {
            var data = await _saleServices.GetSaleBySaleId(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddSale([FromBody] SaleDto data)
        {
            var sale = await _saleServices.AddSale(data);

            var dataProduct = new UpdateProductDto
            {
                ProductId = data.ProductId,
                Quantity = data.Quantity,
            };

            var updateProduct = await _productServices.UpdateProduct(dataProduct);

            var dataSaleItem = new SaleItemDto
            {
                ProductId= data.ProductId,
                Price = data.Price,
                SaleId = sale.SaleId,
                Quantity= data.Quantity,
            };

            var saleItem = await _saleItemServices.AddSaleItem(dataSaleItem);

            return Ok(true);
        }


    }
}
