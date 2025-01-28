using Microsoft.EntityFrameworkCore;
using SistemMaps.Model;

namespace SistemMaps
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Formulir> Formulirs { get; set; }
    }
}
