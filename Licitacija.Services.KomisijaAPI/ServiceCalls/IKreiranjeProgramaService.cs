using Licitacija.Services.KomisijaAPI.Models.ExchangeDtos;

namespace Licitacija.Services.KomisijaAPI.ServiceCalls
{
    public interface IKreiranjeProgramaService
    {
        Task<ProgramDto?> GetProgram(Guid? programId);
    }
}
