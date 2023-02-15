using Licitacija.Services.EtapaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.EtapaAPI.DbContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Etapa> Etape { get; set; }
    }
}
