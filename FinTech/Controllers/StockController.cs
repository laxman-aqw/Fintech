using FinTech.Data;
using FinTech.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("")]
        public ActionResult<List<Stock>> GetStocks()
        {
            var stocks = _context.Stocks.ToList();
            if(stocks == null || stocks.Count==0)
            {
                return NotFound( new { message="No stocks found.", success=false });
            }
            return Ok( new { message="Stocks fetched succesfully", success=true, stocks });
        }

    }
}
