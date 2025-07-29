using stock_api.Models;

namespace stock_api.Repository
{
    public interface ISaleRepository
    {
        Task<List<SaleItem>> GetSaleAll();
        Task<Sale> GetSaleBySaleId(int id);
        Task<Sale> AddSale(Sale data);
    }
}
