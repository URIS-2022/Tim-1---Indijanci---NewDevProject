using Licitacija.Services.KupacAPI.DbContexts;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.KupacAPI.Repositories.ConcreteClasses
{
    public class PrioritetRepository : IPrioritetRepository
    {
        private readonly DataContext _context;

        public PrioritetRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<Prioritet> Get(Guid id)
        {
            return await _context.Prioritet.Where(i => i.PrioritetId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Prioritet>> GetAll()
        {
            return await _context.Prioritet.AsNoTracking().ToListAsync();
        }
    }
}
