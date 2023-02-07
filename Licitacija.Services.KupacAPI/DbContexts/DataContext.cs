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

            modelBuilder.Entity<Kupac>().HasOne(a => a.FizickoLice).WithOne(b => b.Kupac).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Kupac>().HasOne(a => a.PravnoLice).WithOne(b => b.Kupac).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Kupac>().HasOne(a => a.Prioritet).WithMany(b => b.Kupac).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PravnoLice>().HasOne(a => a.KontaktOsoba).WithMany(b => b.PravnoLice).OnDelete(DeleteBehavior.SetNull);

        }

    }
}
