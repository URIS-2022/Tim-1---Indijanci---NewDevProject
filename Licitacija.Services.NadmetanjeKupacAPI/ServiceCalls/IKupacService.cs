using Licitacija.Services.NadmetanjeKupacAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.NadmetanjeKupacAPI.ServiceCalls
{
    public interface IKupacService
    {
        public Task<KupacDto> GetKupacById(Guid kupacId);
    }
}
