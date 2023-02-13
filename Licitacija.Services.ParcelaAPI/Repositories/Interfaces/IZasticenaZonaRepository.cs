using Licitacija.Services.ParcelaAPI.Entities;

namespace Licitacija.Services.ParcelaAPI.Repositories.Interfaces
{
    public interface IZasticenaZonaRepository
    {
        List<ZasticenaZona> GetAll();
        ZasticenaZona GetZasticenaZona(Guid id);
        void InsertZasticenaZona(ZasticenaZona zasticenaZona);
        void DeleteZasticenaZona(Guid id);
        void UpdateZasticenaZona(ZasticenaZona zasticenaZona);
        bool Save();
    }
}
