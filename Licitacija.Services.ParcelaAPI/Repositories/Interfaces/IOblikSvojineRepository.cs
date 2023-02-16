using Licitacija.Services.ParcelaAPI.Entities;

namespace Licitacija.Services.ParcelaAPI.Repositories.Interfaces
{
    public interface IOblikSvojineRepository
    {
        List<OblikSvojine> GetAll();
        OblikSvojine GetOblikSvojine(Guid id);
        void InsertOblikSvojine(OblikSvojine oblikSvojine);
        void DeleteOblikSvojine(Guid id);
        void UpdateOblikSvojine(OblikSvojine oblikSvojine);
        bool Save();
    }
}
