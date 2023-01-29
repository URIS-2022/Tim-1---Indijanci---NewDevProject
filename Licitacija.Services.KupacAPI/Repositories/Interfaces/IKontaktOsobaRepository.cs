using Licitacija.Services.KupacAPI.Entities;

namespace Licitacija.Services.KupacAPI.Repositories.Interfaces
{
    public interface IKontaktOsobaRepository
    {
        Task<IEnumerable<KontaktOsoba>> GetAll();

        Task<KontaktOsoba> Get(Guid id);
    }
}
