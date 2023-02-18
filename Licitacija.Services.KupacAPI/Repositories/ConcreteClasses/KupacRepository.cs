using Licitacija.Services.KupacAPI.DbContexts;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.KupacAPI.Repositories.ConcreteClasses
{
    public class KupacRepository : IKupacRepository
    {
        private readonly DataContext _context;

        public KupacRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<Kupac> Get(Guid id)
        {
            return await _context.Kupac
            .Include(i => i.FizickoLice)
            .Include(i => i.PravnoLice)
            .Include(i=> i.PravnoLice.KontaktOsoba)
            .Include(i => i.Prioritet)
            .Where(i => i.KupacId == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Kupac>> GetAll()
        {
            return await _context.Kupac
               .Include(i => i.FizickoLice)
               .Include(i => i.PravnoLice)
               .Include(i => i.PravnoLice.KontaktOsoba)
               .Include(i => i.Prioritet)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<Kupac> GetKupacBasicInfo(Guid kupacId)
        {
            return await _context.Kupac.Where(i => i.KupacId == kupacId).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Kupac> GetKupacWithTip(Guid kupacId)
        {
            return await _context.Kupac.Where(i => i.KupacId == kupacId).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
