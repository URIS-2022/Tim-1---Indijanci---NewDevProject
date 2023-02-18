using Licitacija.Services.ParcelaAPI.Entities;

namespace Licitacija.Services.ParcelaAPI.Repositories.Interfaces
{
    public interface IObradivostRepository
    {
        List<Obradivost> GetAll();
        Obradivost GetObradivost(Guid id);
        void InsertObradivost(Obradivost obradivost);
        void DeleteObradivost(Guid id);
        void UpdateObradivost(Obradivost obradivost);
        bool Save();
    }
}
