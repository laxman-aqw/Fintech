using FinTech.Data;
using FinTech.Dtos.Stock;
using FinTech.Mappers;
using FinTech.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

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

        [HttpPost]
        public async Task<ActionResult<StockDto>> AddStock([FromBody] CreateStockDto createStockDto) {
            var stockModel = createStockDto.ToStockFromAddDto();
            _context.Stocks.Add(stockModel);
          await   _context.SaveChangesAsync();

            var stockDtoResult = stockModel.ToStockDto();

            return CreatedAtAction(nameof(GetStockById), new {id=stockModel.Id}, stockDtoResult);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<StockDto>> UpdateStock(int Id, [FromBody] UpdateStockDto  updateStockDto) {
            var stockModel = await _context.Stocks.FindAsync(Id);
            if (stockModel == null) {
                return NotFound(new { message = "Stock not found" });
            }
            stockModel.Symbol = updateStockDto.Symbol;
            stockModel.CompanyName= updateStockDto.CompanyName;
            stockModel.Industry= updateStockDto.Industry;
            stockModel.LastDiv = updateStockDto.LastDiv;    
            stockModel.Purchase = updateStockDto.Purchase; 
            stockModel.MarketCap= updateStockDto.MarketCap;
            await _context.SaveChangesAsync();
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<Stock>> DeleteStock(int Id) {
            var stock = await _context.Stocks.FindAsync(Id);
            if (stock == null) {
                return NotFound();
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
