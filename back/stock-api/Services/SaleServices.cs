using Microsoft.EntityFrameworkCore;
using stock_api.Models;
using stock_api.Models.Dto;
using stock_api.Repository;

namespace stock_api.Services
{
    public class SaleServices : ISaleServices
    {
        readonly private ISaleRepository _repo;
        public SaleServices(ISaleRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<SaleItem>> GetSaleAll()
        {
            var data = await _repo.GetSaleAll();
            return data;
        }

        public async Task<Sale> GetSaleBySaleId(int id)
        {
            return await _repo.GetSaleBySaleId(id);
        }

        public async Task<Sale> AddSale(SaleDto data)
        {
            var newData = new Sale
            {
                TotalAmount = data.TotalAmount,
                SaleDate = DateTime.Now,
            };
            return await _repo.AddSale(newData);
        }

    
    }
}
