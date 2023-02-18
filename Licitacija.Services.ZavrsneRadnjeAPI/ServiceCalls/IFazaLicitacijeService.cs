using Licitacija.Services.ZavrsneRadnjeAPI.DTOs.ExchangeDto;

namespace Licitacija.Services.ZavrsneRadnjeAPI.ServiceCalls
{
    public interface IFazaLicitacijeService
    {
        public Task<FazaLicitacijeDto> GetFazaLicitacijeById(Guid fazaId);
    }
}

