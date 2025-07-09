using FinTech.Data;
using FinTech.Interfaces;
using FinTech.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTech.Repository
{
    public class StockRepository: IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context) {
            _context = context;
        }
        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stocks.ToListAsync();
        }
    }
}
