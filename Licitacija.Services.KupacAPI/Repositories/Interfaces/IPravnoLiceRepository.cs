using Licitacija.Services.KupacAPI.Entities;

namespace Licitacija.Services.KupacAPI.Repositories.Interfaces
{
    public interface IPravnoLiceRepository
    {
        Task<IEnumerable<PravnoLice>> GetAll();

        Task<PravnoLice> Get(Guid id);
    }
}
