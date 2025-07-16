using FinTech.Data;
using FinTech.Dtos.Stock;
using FinTech.Helpers;
using FinTech.Interfaces;
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
        private readonly IStockRepository _stockRepo;
        public StockController(IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<StockDto>>> GetStocks([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = (await _stockRepo.GetAllAsync(query)).Select(s=>s.ToStockDto()).ToList();
            if(stocks.Count==0)
            {
                return NotFound( new { message="No stocks found.", success=false });
            }
            return Ok(stocks);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StockDto>> GetStockById( int id) {
            
            var stock = await _stockRepo.GetByIdAsync(id);
            if (stock == null) { 
                return NotFound(new { message = "Stock not found with current id.", success = false });
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<ActionResult<StockDto>> AddStock([FromBody] CreateStockDto createStockDto) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = createStockDto.ToStockFromAddDto();

            var stock = await _stockRepo.CreateAsync(stockModel);
            var stockDtoResult = stock.ToStockDto();

            return CreatedAtAction(nameof(GetStockById), new {id=stock.Id}, stockDtoResult);
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult<StockDto>> UpdateStock(int Id, [FromBody] UpdateStockDto  updateStockDto) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await _stockRepo.UpdateAsync(Id, updateStockDto);
            if (stockModel == null) {
                return NotFound(new { message = "Stock not found" });
            }
           
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<Stock>> DeleteStock(int Id) {
            var stock = await _stockRepo.DeleteAsync(Id);
            if (stock == null) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
