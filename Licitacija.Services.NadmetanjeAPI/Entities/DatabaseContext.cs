using Licitacija.Services.NadmetanjeAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.UplataAPI.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Nadmetanje> Nadmetanje { get; set; } 
        public DbSet<Javno> Javno { get; set; }
        public DbSet<OtvaranjePonuda> OtvaranjePonuda { get; set; }
        public DbSet<StatusNadmetanja> StatusNadmetanja { get; set; }
    }
}
