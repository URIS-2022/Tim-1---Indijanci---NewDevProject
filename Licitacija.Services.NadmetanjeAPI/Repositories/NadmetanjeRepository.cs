using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.UplataAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.NadmetanjeAPI.Repositories
{
    public class NadmetanjeRepository : INadmetanjeRepository
    {
        private readonly DatabaseContext _databaseContext;

        public NadmetanjeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Nadmetanje> GetAll()
        {
            return _databaseContext.Nadmetanje.Include(st => st.StatusNadmetanja).ToList();
        }

        public Nadmetanje GetNadmetanje(Guid id)
        {
            return _databaseContext.Nadmetanje.Include(st => st.StatusNadmetanja).FirstOrDefault(n => n.NadmetanjeId == id);
        }

        public void InsertNadmetanje(Nadmetanje nadmetanje)
        {
            _databaseContext.Add(nadmetanje);
        }

        public void UpdateNadmetanje(Nadmetanje nadmetanje)
        {
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public void DeleteNadmetanje(Guid id)
        {
            _databaseContext.Remove(GetNadmetanje(id));
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }

        public Nadmetanje GetNadmetanjeBasic(Guid id)
        {
            return _databaseContext.Nadmetanje.FirstOrDefault(n => n.NadmetanjeId == id);
        }
    }
}
