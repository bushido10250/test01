using Microsoft.EntityFrameworkCore;
using stock_api.Models;
using stock_api.Repository.Interface;

namespace stock_api.Repository
{

    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _context;
        public SaleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SaleItem>> GetSaleAll()
        {
            var data = await _context.SaleItems.ToListAsync();
            return data;
        }

        public async Task<Sale> GetSaleBySaleId(int id)
        {
            var data = await _context.Sales.Where(x => x.SaleId == id).FirstOrDefaultAsync();
            if (data == null) throw new Exception("Sales Id not found.");
            return data;
        }

        public async Task<Sale> AddSale(Sale data)
        {
            await _context.Sales.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

    }
}
