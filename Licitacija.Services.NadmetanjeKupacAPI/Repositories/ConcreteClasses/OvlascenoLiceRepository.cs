using Licitacija.Services.NadmetanjeKupacAPI.DbContexts;
using Licitacija.Services.NadmetanjeKupacAPI.Entities;
using Licitacija.Services.NadmetanjeKupacAPI.Repositories.Interfaces;

namespace Licitacija.Services.NadmetanjeKupacAPI.Repositories.ConcreteClasses
{
    public class OvlascenoLiceRepository : IOvlascenoLiceRepository
    {
        private readonly DataContext _databaseContext;

        public OvlascenoLiceRepository(DataContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<OvlascenoLice> GetAll()
        {
            return _databaseContext.OvlascenoLice.ToList();
        }

        public OvlascenoLice GetOvlascenoLice(Guid id)
        {
            return _databaseContext.OvlascenoLice.FirstOrDefault(e => e.OvlascenoLiceId == id);
        }

        public void InsertOvlascenoLice(OvlascenoLice ovlascenoLice)
        {
            _databaseContext.Add(ovlascenoLice);
        }

        public void DeleteOvlascenoLice(Guid id)
        {
            _databaseContext.Remove(GetOvlascenoLice(id));
        }

        public void UpdateOvlascenoLice(OvlascenoLice ovlascenoLice)
        {
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }
    }
}
