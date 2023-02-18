using Licitacija.Services.KomisijaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.KomisijaAPI.DbConexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Komisija> Komisija { get; set; } = null!;
        public DbSet<TipKomisije> TipKomisije { get; set; } = null!;
        public DbSet<Licnost> Licnost { get; set; } = null!;
        public DbSet<LicnostKomisija> LicnostKomisija { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LicnostKomisija>().HasKey(c => new { c.LicnostId, c.KomisijaId });
            modelBuilder.Entity<Komisija>().HasOne(k => k.TipKomisije).WithMany(tk => tk.Komisije).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
