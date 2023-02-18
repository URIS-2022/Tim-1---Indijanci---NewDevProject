using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.LicnostKomisijaDtos;

namespace Licitacija.Services.KomisijaAPI.Repositories.Interfaces
{
    public interface ILicnostKomisijaRepository
    {
        Task<List<LicnostKomisija>> GetAllLicnostKomisija();
        Task<LicnostKomisija?> GetLicnostKomisijaById(Guid licnostId, Guid komisijaId);
        LicnostKomisija? AddLicnostKomisija(AddLicnostKomisijaDto addLicnostKomisija, Guid LicnostId);
        Task<LicnostKomisija?> UpdateLicnostKomisija(LicnostKomisija updateLicnostKomisija, Guid komisijaId);
        Task<bool> DeleteLicnostKomisijaById(Guid licnostId, Guid komisijaId);
        Task<int> Save();
    }
}
