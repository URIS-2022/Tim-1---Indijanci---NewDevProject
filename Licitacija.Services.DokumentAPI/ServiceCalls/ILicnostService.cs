using Licitacija.Services.DokumentAPI.Models.ExchangeDtos;

namespace Licitacija.Services.DokumentAPI.ServiceCalls
{
    public interface ILicnostService
    {
        Task<LicnostDto?> GetLicnostZaUgovor(Guid? licnostId);
    }
}
