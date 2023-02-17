using Licitacija.Services.NadmetanjeAPI.Models;

namespace Licitacija.Services.NadmetanjeAPI.ServiceCalls
{
    public interface ILicitacijaService
    {
        Task<LicitacijaDto> GetLicitacijaById(Guid id);
    }
}
