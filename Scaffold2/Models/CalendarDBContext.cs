using Microsoft.EntityFrameworkCore;

namespace Scaffold2.Models
{
    public class CalendarDBContext : DbContext
    {
        public DbSet<CalendarModel> Calendar { get; set; }
        public CalendarDBContext(DbContextOptions<CalendarDBContext> options) : base(options)
        {

        }
    }
}
