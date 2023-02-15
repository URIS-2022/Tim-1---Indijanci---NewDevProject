using Licitacija.Services.ParcelaAPI.Entities;

namespace Licitacija.Services.ParcelaAPI.Repositories.Interfaces
{
    public interface IParcelaRepository
    {
        List<Parcela> GetAll();
        Parcela GetParcela(Guid id);
        void InsertParcela(Parcela parcela);
        void DeleteParcela(Guid id);
        void UpdateParcela(Parcela parcela);
        bool Save();
    }
}
