
using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.TipKomisijeDtos;

namespace Licitacija.Services.TipKomisijeAPI.Repositories.Interfaces
{
    public interface ITipKomisijeRepository
    {
        Task<List<TipKomisije>> GetAllTipoveKomisije();
        Task<TipKomisije?> GetTipKomisijeById(Guid id);
        TipKomisije AddTipKomisije(AddTipKomisijeDto addTipKomisije);
        Task<TipKomisije?> UpdateTipKomisije(UpdateTipKomisijeDto updateTipKomisije);
        Task<bool> DeleteTipKomisijeById(Guid id);
        Task<int> Save();
    }
}
