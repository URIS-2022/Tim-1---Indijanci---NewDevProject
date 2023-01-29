using Licitacija.Services.KupacAPI.DbContexts;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.KupacAPI.Repositories.ConcreteClasses
{
    public class KontaktOsobaRepository : IKontaktOsobaRepository
    {
        private readonly DataContext _context;

        public KontaktOsobaRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<KontaktOsoba> Get(Guid id)
        {
            return await _context.KontaktOsoba.Where(i => i.KontaktOsobaId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<KontaktOsoba>> GetAll()
        {
            return await _context.KontaktOsoba.AsNoTracking().ToListAsync();
        }
    }
}
