using Licitacija.Services.UplataAPI.Entities;

namespace Licitacija.Services.UplataAPI.Repositories
{
    public interface IKursRepository
    {
        List<Kurs> GetAll();
        Kurs GetKurs(Guid id);
        void InsertKurs(Kurs kurs);
        void DeleteKurs(Guid id);
        void UpdateKurs(Kurs kurs);
        bool Save();
    }
}
