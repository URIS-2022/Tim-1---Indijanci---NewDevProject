using Licitacija.Services.UplataAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.UplataAPI.Repositories
{
    public class UplataRepository : IUplataRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UplataRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Uplata> GetAll()
        {
            return _databaseContext.Uplata.Include(i => i.Kurs).ToList();
        }

        public Uplata GetUplata(Guid id)
        {
            return _databaseContext.Uplata.Include(i => i.Kurs).FirstOrDefault(e => e.UplataId == id);
        }

        public void InsertUplata(Uplata uplata)
        {
            _databaseContext.Add(uplata);
        }

        public void DeleteUplata(Guid id)
        {
            _databaseContext.Remove(GetUplata(id));
        }

        public void UpdateUplata(Uplata uplata)
        {
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }

    }
}
