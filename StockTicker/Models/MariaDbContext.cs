using Microsoft.EntityFrameworkCore;

namespace StockTicker.Models
{
    public partial class MariaDbContext : DbContext
    {
        public MariaDbContext(DbContextOptions<MariaDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<StockTickerItem> StockTickerItems { get; set; }
    }
}
