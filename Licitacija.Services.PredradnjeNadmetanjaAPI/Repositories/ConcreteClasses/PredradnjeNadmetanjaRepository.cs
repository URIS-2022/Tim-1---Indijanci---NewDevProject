using Licitacija.Services.PredradnjeNadmetanjaAPI.DbContexts;
using Licitacija.Services.PredradnjeNadmetanjaAPI.Entities;
using Licitacija.Services.PredradnjeNadmetanjaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Repositories.ConcreteClasses
{
    public class PredradnjeNadmetanjaRepository : IPredradnjeNadmetanjaRepository
    {
        private readonly DataContext _context;

        public PredradnjeNadmetanjaRepository(DataContext context)
        {
            _context = context;
        }
    
        public async Task Delete(Guid guid)
        {
            var entity = await _context.PredradnjeNadmetanja.FindAsync(guid);
            _context.PredradnjeNadmetanja.Remove(entity);
        }

        public async Task<PredradnjeNadmetanja> Get(Expression<Func<PredradnjeNadmetanja, bool>> expression)
        {
            return await _context.PredradnjeNadmetanja.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<PredradnjeNadmetanja>> GetAll()
        {
            return await _context.PredradnjeNadmetanja.AsNoTracking().ToListAsync();
        }

        public async Task<PredradnjeNadmetanja> GetPredradnjeBasicInfo(Guid id)
        {
            return await _context.PredradnjeNadmetanja.Where(i => i.PredradnjeNadmetanjaId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task Insert(PredradnjeNadmetanja entity)
        {
            await _context.PredradnjeNadmetanja.AddAsync(entity);
        }

        public void Update(PredradnjeNadmetanja entity)
        {
            _context.PredradnjeNadmetanja.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
