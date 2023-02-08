using Licitacija.Services.AdresaAPI.DbContexts;
using Licitacija.Services.AdresaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.AdresaAPI.Repositories.ConcreteClasses
{
    public class AdresaRepository : IAdresaRepository
    {
        private readonly DataContext _context;

        public AdresaRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<Adresa> Get(Guid id)
        {
            return await _context.Adresa
                .Include(i => i.Drzava)
                .Where(i => i.AdresaId == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Adresa> GetAdresaWithoutDrzava(Guid adresaId)
        {
            return await _context.Adresa.Where(i => i.AdresaId == adresaId).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Adresa>> GetAll()
        {
            return await _context.Adresa.Include(i => i.Drzava).AsNoTracking().ToListAsync();
        }
    }
}
