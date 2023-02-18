using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.ParcelaAPI.ServiceCalls
{
    public interface IEtapaService
    {
        public Task<EtapaBasicInfoDto> GetEtapaById(Guid etapaId);
    }
}
