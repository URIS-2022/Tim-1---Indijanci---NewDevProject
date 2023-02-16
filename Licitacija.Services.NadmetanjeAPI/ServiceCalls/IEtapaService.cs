using Licitacija.Services.NadmetanjeAPI.Models;

namespace Licitacija.Services.NadmetanjeAPI.ServiceCalls
{
    public interface IEtapaService
    {
        Task<EtapaDto> GetEtapaById(Guid id);
    }
}
