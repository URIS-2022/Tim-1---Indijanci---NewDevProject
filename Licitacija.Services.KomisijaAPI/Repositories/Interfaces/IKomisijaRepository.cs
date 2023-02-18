using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.KomisijaDtos;

namespace Licitacija.Services.KomisijaAPI.Repositories.Interfaces
{
    public interface IKomisijaRepository
    {
        Task<List<Komisija>> GetAllKomisije();
        Task<Komisija?> GetKomisijaById(Guid id);
        Komisija AddKomisija(AddKomisijaDto addKomisija);
        Task<Komisija?> UpdateKomisija(UpdateKomisijaDto updateKomisija);
        Task<bool> DeleteKomisijaById(Guid id);
        Task<int> Save();
    }
}
