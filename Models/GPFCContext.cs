using Microsoft.EntityFrameworkCore;

namespace GPFC_Management.Models
{
    public class GPFCContext : DbContext
    {
        public GPFCContext(DbContextOptions<GPFCContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}