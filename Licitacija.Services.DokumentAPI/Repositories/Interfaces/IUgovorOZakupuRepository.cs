using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.UgovorOZakupuDtos;

namespace Licitacija.Services.DokumentAPI.Repositories.Interfaces
{
    public interface IUgovorOZakupuRepository
    {
        Task<List<UgovorOZakupu>> GetAllUgovorOZakupu();
        Task<UgovorOZakupu?> GetUgovorOZakupuById(Guid id);
        UgovorOZakupu AddUgovorOZakupu(AddUgovorOZakupuDto addUgovorOZakupu);
        Task<UgovorOZakupu?> UpdateUgovorOZakupu(UpdateUgovorOZakupuDto updateUgovorOZakupu);
        Task<bool> DeleteUgovorOZakupuById(Guid id);
        Task<int> Save();
    }
}
