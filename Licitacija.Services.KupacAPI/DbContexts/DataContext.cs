using Licitacija.Services.KupacAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.KupacAPI.DbContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Prioritet> Prioritet { get; set; } = null!;
        public DbSet<KontaktOsoba> KontaktOsoba { get; set; } = null!;
        
    }
}
