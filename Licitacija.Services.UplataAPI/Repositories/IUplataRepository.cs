using Licitacija.Services.UplataAPI.Entities;

namespace Licitacija.Services.UplataAPI.Repositories
{
    public interface IUplataRepository
    {
        List<Uplata> GetAll();
        Uplata GetUplata(Guid id);
        void InsertUplata(Uplata uplata);
        void DeleteUplata(Guid id);
        void UpdateUplata(Uplata uplata);
        bool Save();
    }
}
