using Licitacija.Services.AdresaAPI.DbContexts;
using Licitacija.Services.AdresaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.AdresaAPI.Repositories.ConcreteClasses
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task Delete(Guid guid)
        {
            var entity = await _db.FindAsync(guid);
            _db.Remove(entity);
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);//provera da li postoje neke razlike izmedju ovog entiteta i onoga sta postoji u bazi i primenjuje ih
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
