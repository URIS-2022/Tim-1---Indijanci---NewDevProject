using Licitacija.Services.NadmetanjeAPI.Models;

namespace Licitacija.Services.NadmetanjeAPI.ServiceCalls
{
    public interface IAdresaService
    {
        Task<AdresaDto> GetAdresaById(Guid id);
    }
}
