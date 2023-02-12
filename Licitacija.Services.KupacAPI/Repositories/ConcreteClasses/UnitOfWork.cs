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
        private IGenericRepository<FizickoLice> _fizickoLice;
        private IGenericRepository<PravnoLice> _pravnoLice;
        private IGenericRepository<Kupac> _kupac;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IGenericRepository<Prioritet> Prioritet => _prioritet ??= new GenericRepository<Prioritet>(_context);

        public IGenericRepository<KontaktOsoba> KontaktOsoba => _kontaktOsoba ??= new GenericRepository<KontaktOsoba>(_context);

        public IGenericRepository<FizickoLice> FizickoLice => _fizickoLice ??= new GenericRepository<FizickoLice>(_context);

        public IGenericRepository<PravnoLice> PravnoLice => _pravnoLice ??= new GenericRepository<PravnoLice>(_context);

        public IGenericRepository<Kupac> Kupac => _kupac ??= new GenericRepository<Kupac>(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
