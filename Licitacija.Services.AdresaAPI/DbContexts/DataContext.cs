global using Licitacija.Services.AdresaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.AdresaAPI.DbContexts
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions options) : base(options) { }

        public DbSet<Adresa> Adresa { get; set; } = null!;
        public DbSet<Drzava> Drzava { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresa>().HasOne(a => a.Drzava).WithMany(b => b.Adresa).OnDelete(DeleteBehavior.SetNull);
        }
    }

}
