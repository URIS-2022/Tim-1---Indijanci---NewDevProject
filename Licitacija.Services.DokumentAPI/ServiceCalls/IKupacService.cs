using Licitacija.Services.DokumentAPI.Models.ExchangeDtos;

namespace Licitacija.Services.DokumentAPI.ServiceCalls
{
    public interface IKupacService
    {
        Task<KupacDto?> GetKupacWithTip(Guid? kupacId);
    }
}
