using Licitacija.Services.PredradnjeNadmetanjaAPI.Entities;
using System.Linq.Expressions;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Repositories.Interfaces
{
    public interface IPredradnjeNadmetanjaRepository : IDisposable
    {
        Task<IEnumerable<PredradnjeNadmetanja>> GetAll();

        Task<PredradnjeNadmetanja> Get(Expression<Func<PredradnjeNadmetanja, bool>> expression);

        Task<PredradnjeNadmetanja> GetPredradnjeBasicInfo(Guid id);

        Task Insert(PredradnjeNadmetanja entity);

        Task Delete(Guid guid);

        void Update(PredradnjeNadmetanja entity);

        Task Save();
    }
}
