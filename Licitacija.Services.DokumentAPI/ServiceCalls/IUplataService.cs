using Licitacija.Services.DokumentAPI.Models.ExchangeDtos;

namespace Licitacija.Services.DokumentAPI.ServiceCalls
{
    public interface IUplataService
    {
        Task<UplataDto?> GetUplataZaUgovor(Guid? uplataId);
    }
}
