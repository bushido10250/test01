using stock_api.Models;
using stock_api.Models.Dto;

namespace stock_api.Services
{
    public interface ISaleServices
    {
        Task<List<SaleItem>> GetSaleAll();
        Task<Sale> GetSaleBySaleId(int id);
        Task<Sale> AddSale(SaleDto data);
    }
}
