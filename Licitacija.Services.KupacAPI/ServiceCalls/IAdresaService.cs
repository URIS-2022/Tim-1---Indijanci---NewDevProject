using Licitacija.Services.KupacAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.KupacAPI.ServiceCalls
{
    public interface IAdresaService
    {
        public Task<AdresaDTO> GetAdresaById(Guid adresaId);
    }
}
