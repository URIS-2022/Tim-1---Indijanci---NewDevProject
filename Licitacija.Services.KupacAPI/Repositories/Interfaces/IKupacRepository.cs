using Licitacija.Services.KupacAPI.Entities;

namespace Licitacija.Services.KupacAPI.Repositories.Interfaces
{
    public interface IKupacRepository
    {
        Task<IEnumerable<Kupac>> GetAll();

        Task<Kupac> Get(Guid id);
    }
}
