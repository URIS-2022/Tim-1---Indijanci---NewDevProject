using Licitacija.Services.NadmetanjeAPI.Models;

namespace Licitacija.Services.NadmetanjeAPI.ServiceCalls
{
    public interface IFazaLicitacijeService
    {
        Task<FazaDto> GetFazaLicitacijeById(Guid id);
    }
}
