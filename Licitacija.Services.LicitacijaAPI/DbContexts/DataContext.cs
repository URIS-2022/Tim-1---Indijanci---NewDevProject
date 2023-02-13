using Licitacija.Services.LicitacijaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.LicitacijaAPI.DbContexts
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
  
        }

        public DbSet<LicitacijaEntity> Licitacija { get; set; }

        public DbSet<FazaLicitacije> FazaLicitacije { get; set; }

    }
}
