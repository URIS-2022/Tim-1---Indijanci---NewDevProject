using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.ParcelaAPI.ServiceCalls
{
    public interface IOtvaranjePonudaService
    {
        public Task<OtvaranjePonudaBasicInfoDto> GetOtvaranjePonudaById(Guid otvaranjePonudaId);
    }
}
