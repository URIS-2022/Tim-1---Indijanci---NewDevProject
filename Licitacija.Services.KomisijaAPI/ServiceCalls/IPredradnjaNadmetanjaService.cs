using Licitacija.Services.KomisijaAPI.Models.ExchangeDtos;

namespace Licitacija.Services.KomisijaAPI.ServiceCalls
{
    public interface IPredradnjaNadmetanjaService
    {
        Task<PredradnjaNadmetanjaDto?> GetPredradnjaNadmetanja(Guid? predradnjaNadmetanjaId);
    }
}
