using Licitacija.Services.ProgramLicitacijeAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.ProgramLicitacijeAPI.DbConexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<KreiranjeProgramaLicitacije> KreiranjeProgramaLicitacije { get; set; } = null!;

    }
}
