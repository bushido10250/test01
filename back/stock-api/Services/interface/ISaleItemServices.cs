using stock_api.Models;
using stock_api.Models.Dto;

namespace stock_api.Services.Interface
{
    public interface ISaleItemServices
    {
        Task<List<SaleItem>> GetSaleItemAll();
        Task<List<SaleItem>> GetSaleItemBySaleId(int id);
        Task<SaleItem> AddSaleItem(SaleItemDto data);
    }
}
