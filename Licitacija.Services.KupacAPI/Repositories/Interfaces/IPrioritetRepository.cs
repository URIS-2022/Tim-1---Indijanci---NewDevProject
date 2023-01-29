using Licitacija.Services.KupacAPI.Entities;

namespace Licitacija.Services.KupacAPI.Repositories.Interfaces
{
    public interface IPrioritetRepository
    {
        Task<IEnumerable<Prioritet>> GetAll();

        Task<Prioritet> Get(Guid id);
    }
}
