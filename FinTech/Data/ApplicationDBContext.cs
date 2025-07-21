using FinTech.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FinTech.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Stock>Stocks { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
    }
}
