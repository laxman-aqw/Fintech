using FinTech.Dtos.Stock;
using FinTech.Models;

namespace FinTech.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> DeleteAsync(int id);
        Task<Stock?> UpdateAsync(int id, UpdateStockDto stockDto);
    }
}
