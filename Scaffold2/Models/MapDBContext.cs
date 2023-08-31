using Microsoft.EntityFrameworkCore;

namespace Scaffold2.Models
{
    public class MapDBContext : DbContext
    {
        public DbSet<MapMarker> News { get; set; }
        public MapDBContext(DbContextOptions<MapDBContext> options) : base(options)
        {

        }
    }
}
