using stock_api.Models;
using stock_api.Models.Dto;
using stock_api.Repository;
using stock_api.Repository.Interface;
using stock_api.Services.Interface;

namespace stock_api.Services
{
    public class SaleItemServices : ISaleItemServices
    {
        readonly private ISaleItemRepository _repo;
        public SaleItemServices(ISaleItemRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<SaleItem>> GetSaleItemAll()
        {
            return await _repo.GetSaleItemAll();
        }

        public async Task<List<SaleItem>> GetSaleItemBySaleId(int id)
        {
            return await _repo.GetSaleItemBySaleId(id);
        }    
        public async Task<SaleItem> AddSaleItem(SaleItemDto data)
        {
            var newData = new SaleItem
            {
                SaleId = data.SaleId,
                ProductId = data.ProductId,
                Price = data.Price,
                Quantity = data.Quantity,
            };
            return await _repo.AddSaleItem(newData);
        }
    }
}
