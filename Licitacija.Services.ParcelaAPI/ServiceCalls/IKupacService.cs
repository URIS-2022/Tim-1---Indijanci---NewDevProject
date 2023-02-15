using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.ParcelaAPI.ServiceCalls
{
    public interface IKupacService
    {
        public Task<KupacBasicInfoDTO> GetKupacById(Guid kupacId);
    }
}
