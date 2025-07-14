using FinTech.Data;
using FinTech.Dtos.Stock;
using FinTech.Interfaces;
using FinTech.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTech.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            var stock = await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return null;
            }
            return stock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return null;
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }
        public async Task<Stock?> UpdateAsync(int id, UpdateStockDto stockDto)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return null;
            }
            stock.Symbol = stockDto.Symbol;
            stock.CompanyName = stockDto.CompanyName;
            stock.Industry = stockDto.Industry;
            stock.LastDiv = stockDto.LastDiv;
            stock.Purchase = stockDto.Purchase;
            stock.MarketCap = stockDto.MarketCap;
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<bool> StockExist(int id)
        {
            return await _context.Stocks.AnyAsync(s => s.Id == id);
        }
    }
}
