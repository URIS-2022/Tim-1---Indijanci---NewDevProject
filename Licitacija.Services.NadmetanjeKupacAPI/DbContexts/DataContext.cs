using Licitacija.Services.NadmetanjeKupacAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.NadmetanjeKupacAPI.DbContexts
{
    public class DataContext : DbContext
    {
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        public DataContext(DbContextOptions options, IConfiguration configuration) : base(options) { }

        public DbSet<OvlascenoLice> OvlascenoLice { get; set; }
        public DbSet<NadmetanjeKupacEntity> NadmetanjeKupac { get; set; }
    }
}
