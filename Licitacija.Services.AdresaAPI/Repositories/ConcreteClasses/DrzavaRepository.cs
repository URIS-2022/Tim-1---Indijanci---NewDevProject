using Licitacija.Services.AdresaAPI.DbContexts;
using Licitacija.Services.AdresaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.AdresaAPI.Repositories.ConcreteClasses
{
    public class DrzavaRepository : IDrzavaRepository
    {
        private readonly DataContext _context;

        public DrzavaRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<Drzava> Get(Guid id)
        {
            return await _context.Drzava.Where(i => i.DrzavaId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Drzava>> GetAll()
        {
            return await _context.Drzava.AsNoTracking().ToListAsync();
        }
    }
}
