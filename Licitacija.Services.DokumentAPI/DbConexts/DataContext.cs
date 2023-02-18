using Licitacija.Services.DokumentAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.DokumentAPI.DbConexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Dokument> Dokument { get; set; } = null!;
        public DbSet<EksterniDokument> EksterniDokument { get; set; } = null!;
        public DbSet<StatusDokumenta> StatusDokumenta { get; set; } = null!;
        public DbSet<TipGarancije> TipGarancije { get; set; } = null!;
        public DbSet<UgovorOZakupu> UgovorOZakupu { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Dokument>().HasOne(d => d.EksterniDokument).WithOne(ed => ed.Dokument).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dokument>().HasOne(d => d.UgovorOZakupu).WithOne(uz => uz.Dokument).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dokument>().HasOne(d => d.StatusDokumenta).WithMany(s => s.Dokumenti).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UgovorOZakupu>().HasOne(uz => uz.TipGarancije).WithMany(tg => tg.UgovoriOZakupu).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
