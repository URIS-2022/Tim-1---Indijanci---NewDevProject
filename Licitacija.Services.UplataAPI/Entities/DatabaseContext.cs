using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.UplataAPI.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Kurs> Kurs { get; set; } 
        public DbSet<Uplata> Uplata { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Kurs>()
                .Property(p => p.Vrednost)
                .HasColumnType("decimal(18,4)");

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Uplata>()
                .Property(p => p.Iznos)
                .HasColumnType("decimal(18,4)");
        }
    }
}
