using Licitacija.Services.AdresaAPI.DbContexts;
using Licitacija.Services.AdresaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

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

        public async Task<T> Get(Expression<Func<T, bool>>? expression = null)
        {
            IQueryable<T> query = _db;//uzima sve torke koji su u tabeli datog tipa T

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);//expression se odnosi na ono po cemu se filtriraju podaci npr po id(lambda)
        }

        public async Task<IList<T>> GetAll()
        {
            return await _db.AsNoTracking().ToListAsync();//asnotracking ne sacuvavavju se izmene automatski (brze i koristi se za get req)
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);//provera da li postoje neke razlike izmedju ovog entiteta i onoga sta postoji u bazi
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
