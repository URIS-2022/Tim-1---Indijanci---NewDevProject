using Licitacija.Services.ProgramLicitacijeAPI.Models.ExchangeDtos;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.ServiceCalls
{
    public interface ILicitacijaService
    {
        public Task<FazaDto?> GetFazaById(Guid? fazaid);
    }
}
