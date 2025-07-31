using FinTech.Dtos.Stock;
using FinTech.Helpers;
using FinTech.Models;

namespace FinTech.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> DeleteAsync(int id);
        Task<Stock?> UpdateAsync(int id, UpdateStockDto stockDto);
        Task<bool> StockExist(int id);
    }
}
