using stock_api.Models;
using stock_api.Models.Dto;

namespace stock_api.Services.Interface
{
    public interface IProductServices
    {
        Task<List<Product>> GetProductAll();
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(ProductDto data);
        Task<CheckProductDto> CheckProduct(ProductCheckDto data);
        Task<bool> UpdateProduct(UpdateProductDto data);

    }
}
