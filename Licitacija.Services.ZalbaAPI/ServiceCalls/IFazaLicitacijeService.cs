using Licitacija.Services.ZalbaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.ZalbaAPI.ServiceCalls
{
    public interface IFazaLicitacijeService
    {
        public Task<FazaLicitacijeDto> GetFazaLicitacijeById(Guid fazaId);
    }
}
