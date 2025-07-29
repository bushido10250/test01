using stock_api.Models;
using stock_api.Models.Dto;

namespace stock_api.Repository.Interface
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProductAll();
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product data);
        Task<CheckProductDto> CheckProduct(Product data);
        Task<bool> UpdateProduct(UpdateProductDto data);
    }
}
