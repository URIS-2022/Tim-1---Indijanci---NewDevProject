using Licitacija.Services.DokumentAPI.DbConexts;
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.EksterniDokumentDtos;

namespace Licitacija.Services.DokumentAPI.Repositories.Interfaces
{
    public interface IEksterniDokumentRepository
    {
        Task<List<EksterniDokument>> GetAllEksterneDokumente();
        Task<EksterniDokument?> GetEksterniDokumentById(Guid id);
        EksterniDokument AddEksterniDokument(AddEksterniDokumentDto addEksterniDokument);
        Task<EksterniDokument?> UpdateEksterniDokument(UpdateEksterniDokumentDto updateEksterniDokument);
        Task<bool> DeleteEksterniDokumentById(Guid id);
        Task<int> Save();
    }
}
