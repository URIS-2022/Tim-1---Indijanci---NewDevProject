using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.LicnostDtos;

namespace Licitacija.Services.LicnostAPI.Repositories.Interfaces
{
    public interface ILicnostRepository
    {
        Task<List<Licnost>> GetAllLicnosti();
        Task<Licnost?> GetLicnostById(Guid id);
        Licnost AddLicnost(AddLicnostDto addLicnost);
        Task<Licnost?> UpdateLicnost(UpdateLicnostDto updateLicnost);
        Task<bool> DeleteLicnostById(Guid id);
        Task<int> Save();
    }
}
