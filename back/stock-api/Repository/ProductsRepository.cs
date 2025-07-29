using Microsoft.EntityFrameworkCore;
using stock_api.Models;
using stock_api.Models.Dto;
using stock_api.Repository.Interface;
using System.Linq;

namespace stock_api.Repository
{

    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext _context;
        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null) throw new Exception("Product Id not found.");
            return product;
        }

        public async Task<Product> AddProduct(Product data)
        {
            await _context.Products.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<CheckProductDto> CheckProduct(Product data)
        {
            var rawData = await _context.Products.Where(x=>x.ProductId == data.ProductId).FirstOrDefaultAsync();
            if (rawData == null) throw new Exception("Product Id not found.");

            var result = rawData.StockQuantity < data.StockQuantity;

            var newData = new CheckProductDto
            {
                ProductId = data.ProductId,
                IsOver = result
            };
            return newData;
        }

        public async Task<bool> UpdateProduct(UpdateProductDto data)
        {
            var product = await _context.Products.Where(x => x.ProductId == data.ProductId).FirstOrDefaultAsync();
            if (product == null) throw new Exception("Product Id not found.");

            product.StockQuantity -= data.Quantity;

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

    }
}
