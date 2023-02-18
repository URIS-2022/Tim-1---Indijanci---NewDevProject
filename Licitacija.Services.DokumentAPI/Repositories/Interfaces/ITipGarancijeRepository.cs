using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.TipGarancijeDtos;

namespace Licitacija.Services.DokumentAPI.Repositories.Interfaces
{
    public interface ITipGarancijeRepository
    {
        Task<List<TipGarancije>> GetAllTipGarancije();
        Task<TipGarancije?> GetTipGarancijeById(Guid id);
        TipGarancije AddTipGarancije(AddTipGarancijeDto addTipGarancije);
        Task<TipGarancije?> UpdateTipGarancije(UpdateTipGarancijeDto updateTipGarancije);
        Task<bool> DeleteTipGarancijeById(Guid id);
        Task<int> Save();
    }
}
