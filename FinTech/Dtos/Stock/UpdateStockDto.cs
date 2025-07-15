using FinTech.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinTech.Dtos.Stock
{
    public class UpdateStockDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be more than 10 letter")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Company name cannot be more than 10 letter")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 10000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Industry cannot be more than 10 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1, 50000000000)]
        public long MarketCap { get; set; }
    }
}
