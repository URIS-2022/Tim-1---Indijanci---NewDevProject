using Licitacija.Services.ParcelaAPI.Entities;

namespace Licitacija.Services.ParcelaAPI.Repositories.Interfaces
{
    public interface IKlasaRepository
    {
        List<Klasa> GetAll();
        Klasa GetKlasa(Guid id);
        void InsertKlasa(Klasa klasa);
        void DeleteKlasa(Guid id);
        void UpdateKlasa(Klasa klasa);
        bool Save();
    }
}
