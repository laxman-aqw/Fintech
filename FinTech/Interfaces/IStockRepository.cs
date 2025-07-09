using FinTech.Models;

namespace FinTech.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
    }
}
