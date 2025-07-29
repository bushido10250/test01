using stock_api.Models;

namespace stock_api.Repository.Interface
{
    public interface ISaleItemRepository
    {
        Task<List<SaleItem>> GetSaleItemAll();
        Task<List<SaleItem>> GetSaleItemBySaleId(int id);
        Task<SaleItem> AddSaleItem(SaleItem data);
    }
}
