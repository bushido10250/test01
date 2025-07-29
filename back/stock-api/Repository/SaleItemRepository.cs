using Microsoft.EntityFrameworkCore;
using stock_api.Models;
using stock_api.Repository.Interface;

namespace stock_api.Repository
{

    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly AppDbContext _context;
        public SaleItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SaleItem>> GetSaleItemAll()
        {
            var data = await _context.SaleItems.ToListAsync();
            return data;
        }

        public async Task<List<SaleItem>> GetSaleItemBySaleId(int id)
        {
            var data = await _context.SaleItems.Where(x => x.SaleId == id).ToListAsync();
            return data;
        }

        public async Task<SaleItem> AddSaleItem(SaleItem data)
        {
            await _context.SaleItems.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

    }
}
