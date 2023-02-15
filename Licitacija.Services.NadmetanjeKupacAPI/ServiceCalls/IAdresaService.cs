using Licitacija.Services.NadmetanjeKupacAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.NadmetanjeKupacAPI.ServiceCalls
{
    public interface IAdresaService
    {
        public Task<AdresaDto> GetAdresaById(Guid adresaId);
    }
}
