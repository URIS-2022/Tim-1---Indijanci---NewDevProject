using Licitacija.Services.KupacAPI.DbContexts;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.KupacAPI.Repositories.ConcreteClasses
{
    public class PravnoLiceRepository : IPravnoLiceRepository
    {
        private readonly DataContext _context;

        public PravnoLiceRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<PravnoLice> Get(Guid id)
        {
            return await _context.PravnoLice
                .Include(i => i.KontaktOsoba)
                .Where(i => i.PravnoLiceId == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PravnoLice>> GetAll()
        {
            return await _context.PravnoLice.Include(i => i.KontaktOsoba).AsNoTracking().ToListAsync();
        }
    }
}
