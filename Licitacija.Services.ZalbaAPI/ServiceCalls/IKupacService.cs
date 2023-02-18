using Licitacija.Services.ZalbaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.ZalbaAPI.ServiceCalls
{
    public interface IKupacService
    {
        public Task<KupacDto> GetKupacById(Guid kupacId);
    }
}
