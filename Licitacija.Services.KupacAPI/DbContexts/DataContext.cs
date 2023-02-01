using Licitacija.Services.KupacAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.KupacAPI.DbContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Prioritet> Prioritet { get; set; } = null!;
        public DbSet<KontaktOsoba> KontaktOsoba { get; set; } = null!;

        public DbSet<Kupac> Kupac { get; set; } = null!;

        public DbSet<FizickoLice> FizickoLice { get; set; } = null!;

        public DbSet<PravnoLice> PravnoLice { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FizickoLice>().HasKey(x => new { x.FizickoLiceId, x.KupacId });

            modelBuilder.Entity<PravnoLice>().HasKey(x => new { x.PravnoLiceId, x.KupacId });
        }
        
    }
}
