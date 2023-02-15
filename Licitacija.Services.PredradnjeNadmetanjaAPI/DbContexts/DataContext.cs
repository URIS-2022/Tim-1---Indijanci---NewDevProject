using Licitacija.Services.PredradnjeNadmetanjaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.DbContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<PredradnjeNadmetanja> PredradnjeNadmetanja { get; set; } = null!;

    }
}
