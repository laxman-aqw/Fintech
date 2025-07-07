using FinTech.Data;
using FinTech.Dtos.Stock;
using FinTech.Mappers;
using FinTech.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<StockDto>>> GetStocks()
        {
            var stocks = (await _context.Stocks.ToListAsync()).Select(s=>s.ToStockDto()).ToList();
            if(stocks.Count==0)
            {
                return NotFound( new { message="No stocks found.", success=false });
            }
            return Ok(stocks);
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<StockDto>> GetStockById(int id) {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null) { 
                return NotFound(new { message = "Stock not found with current id.", success = false });
            }
            return Ok(stock.ToStockDto());
        }

    }
}
