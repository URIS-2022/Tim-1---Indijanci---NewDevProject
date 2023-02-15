using Licitacija.Services.NadmetanjeKupacAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.NadmetanjeKupacAPI.ServiceCalls
{
    public interface INadmetanjeService
    {
        public Task<NadmetanjeDto> GetNadmetanjeById(Guid nadmetanjeId);
    }
}
