using Licitacija.Services.ParcelaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.ParcelaAPI.DbContexts
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options, IConfiguration configuration) : base(options) {}

        public DbSet<DeoParcele> DeloviParcele { get; set; }
        public DbSet<KatastarskaOpstina> KatastarskeOpstine { get; set; }
        public DbSet<Klasa> Klase { get; set; }
        public DbSet<Kultura> Kulture { get; set; }
        public DbSet<OblikSvojine> ObliciSvojina { get; set; }
        public DbSet<Obradivost> Obradivosti { get; set; } 
        public DbSet<Odvodnjavanje> Odvodnjavanja { get; set; } 
        public DbSet<Parcela> Parcele { get; set; }
        public DbSet<Povrsina> Povrsine { get; set; }
        public DbSet<ZasticenaZona> ZasticeneZone { get; set; }

    }
    
}
