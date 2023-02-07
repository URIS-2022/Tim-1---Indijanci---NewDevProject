using Licitacija.Services.KupacAPI.Entities;
using System.Linq.Expressions;

namespace Licitacija.Services.KupacAPI.Repositories.Interfaces
{
    
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(Expression<Func<T, bool>> expression);

        Task Insert(T entity);

        Task Delete(Guid guid);

        void Update(T entity);
    }
}
