using Licitacija.Services.ZalbaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.ZalbaAPI.DbContexts
{
    public class DataContext : DbContext
    {

        /// <param name="options"></param>
        /// <param name="configuration"></param>
        public DataContext(DbContextOptions options, IConfiguration configuration) : base(options){}

        public DbSet<Zalba> Zalbe { get; set; }
        public DbSet<TipZalbe> TipoviZalbi { get; set; }
        public DbSet<StatusZalbe> StatusiZalbi { get; set; }
        public DbSet<RadnjaNaOsnovuZalbe> RadnjeNaOsnovuZalbe { get; set; }

    }
}
