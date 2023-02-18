using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.DokumentDtos;

namespace Licitacija.Services.DokumentAPI.Repositories.Interfaces
{
    public interface IDokumentRepository
    {
        Task<List<Dokument>> GetAllDokumente();
        Task<Dokument?> GetDokumentById(Guid id);
        Dokument AddDokument(AddDokumentDto addDokument);
        Task<Dokument?> UpdateDokument(UpdateDokumentDto updateDokument);
        Task<bool> DeleteDokumentById(Guid id);
        Task<int> Save();
    }
}
