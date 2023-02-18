using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.StatusDokumentaDtos;

namespace Licitacija.Services.DokumentAPI.Repositories.Interfaces
{
    public interface IStatusDokumentaRepository
    {
        Task<List<StatusDokumenta>> GetAllStatusDokumenta();
        Task<StatusDokumenta?> GetStatusDokumentaById(Guid id);
        StatusDokumenta AddStatusDokumenta(AddStatusDokumentaDto statusDokumenta);
        Task<StatusDokumenta?> UpdateStatusDokumenta(UpdateStatusDokumentaDto statusDokumenta);
        Task<bool> DeleteStatusDokumentaById(Guid id);
        Task<int> Save();
    }
}
