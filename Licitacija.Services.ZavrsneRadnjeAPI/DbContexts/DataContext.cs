using Licitacija.Services.ZavrsneRadnjeAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.ZavrsneRadnjeAPI.DbContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<ZavrsneRadnje> ZavrsneRadnje { get; set; } = null!;

    }
}
