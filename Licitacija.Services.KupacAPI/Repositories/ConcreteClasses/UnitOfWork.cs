using Licitacija.Services.KupacAPI.DbContexts;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;

namespace Licitacija.Services.KupacAPI.Repositories.ConcreteClasses
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IGenericRepository<Prioritet> _prioritet;
        private IGenericRepository<KontaktOsoba> _kontaktOsoba;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IGenericRepository<Prioritet> Prioritet => _prioritet ??= new GenericRepository<Prioritet>(_context);

        public IGenericRepository<KontaktOsoba> KontaktOsoba => _kontaktOsoba ??= new GenericRepository<KontaktOsoba>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
