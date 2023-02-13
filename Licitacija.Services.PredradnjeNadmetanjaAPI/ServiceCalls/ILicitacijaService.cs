using Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.ServiceCalls
{
    public interface ILicitacijaService
    {
        public Task<FazaDto> GetFazaById(Guid fazaid);
    }
}
