using Licitacija.Services.NadmetanjeKupacAPI.DbContexts;
using Licitacija.Services.NadmetanjeKupacAPI.Entities;
using Licitacija.Services.NadmetanjeKupacAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.NadmetanjeKupacAPI.Repositories.ConcreteClasses
{
    public class NadmetanjeKupacRepository : INadmetanjeKupacRepository
    {
        private readonly DataContext _databaseContext;

        public NadmetanjeKupacRepository(DataContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<NadmetanjeKupacEntity> GetAll()
        {
            return _databaseContext.NadmetanjeKupac.Include(i => i.OvlascenoLice).ToList();
        }

        public NadmetanjeKupacEntity GetNadmetanjeKupac(Guid id)
        {
            return _databaseContext.NadmetanjeKupac.Include(i => i.OvlascenoLice).FirstOrDefault(e => e.NadmetanjeKupacId == id);
        }

        public void InsertNadmetanjeKupac(NadmetanjeKupacEntity nadmetanjeKupac)
        {
            _databaseContext.Add(nadmetanjeKupac);
        }

        public void UpdateNadmetanjeKupac(NadmetanjeKupacEntity nadmetanjeKupac)
        {
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public void DeleteNadmetanjeKupac(Guid id)
        {
            _databaseContext.Remove(GetNadmetanjeKupac(id));
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }
    }
}
