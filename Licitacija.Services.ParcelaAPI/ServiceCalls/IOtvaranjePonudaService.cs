using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.ParcelaAPI.ServiceCalls
{
    public interface IOtvaranjePonudaService
    {
        public Task<OtvaranjePonudaBasicInfoDTO> GetOtvaranjePonudaById(Guid nadmetanjeId);
    }
}
