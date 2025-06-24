using Microsoft.EntityFrameworkCore;

namespace BallonGame.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<BallonGame.Models.Users> Users { get; set; }
    }
    
}
