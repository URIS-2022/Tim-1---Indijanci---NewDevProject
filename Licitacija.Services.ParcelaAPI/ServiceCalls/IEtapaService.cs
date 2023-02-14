using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.ParcelaAPI.ServiceCalls
{
    public interface IEtapaService
    {
        public Task<EtapaBasicInfoDTO> GetEtapaById(Guid etapaId);
    }
}
