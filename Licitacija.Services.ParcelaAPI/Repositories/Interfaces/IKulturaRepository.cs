using Licitacija.Services.ParcelaAPI.Entities;

namespace Licitacija.Services.ParcelaAPI.Repositories.Interfaces
{
    public interface IKulturaRepository
    {
        List<Kultura> GetAll();
        Kultura GetKultura(Guid id);
        void InsertKultura(Kultura kultura);
        void DeleteKultura(Guid id);
        void UpdateKultura(Kultura kultura);
        bool Save();
    }
}
