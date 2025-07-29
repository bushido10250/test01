using stock_api.Models;
using stock_api.Models.Dto;
using stock_api.Repository.Interface;
using stock_api.Services.Interface;

namespace stock_api.Services
{
  
    public class ProductServices : IProductServices
    {
        readonly private IProductsRepository _repo;

        public ProductServices(IProductsRepository repo) {
            _repo = repo;
        }

        public async Task<List<Product>> GetProductAll()
        {
            return await _repo.GetProductAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _repo.GetProductById(id);
        }

        public async Task<Product> AddProduct(ProductDto data)
        {
            var newProduct = new Product
            {
                ProductName = data.ProductName,
                Price = data.Price,
                Description = data.Description,
                CreateDate = DateTime.Now,
                StockQuantity = data.StockQuantity,
            };
            return await _repo.AddProduct(newProduct);
        }

        public async Task<CheckProductDto> CheckProduct(ProductCheckDto data)
        {
            var newData = new Product
            {
                ProductId = data.ProductId,
                StockQuantity = data.Amount
            };
            return await _repo.CheckProduct(newData);
        }

        public async Task<bool> UpdateProduct(UpdateProductDto data)
        {
            return await _repo.UpdateProduct(data);
        }

    }
}
