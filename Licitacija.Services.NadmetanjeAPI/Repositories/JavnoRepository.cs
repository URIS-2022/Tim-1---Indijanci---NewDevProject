using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.UplataAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.NadmetanjeAPI.Repositories
{
    public class JavnoRepository : IJavnoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public JavnoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Javno> GetAll()
        {
            return _databaseContext.Javno.Include(n => n.Nadmetanje).ToList();
        }

        public Javno GetJavno(Guid id)
        {
            return _databaseContext.Javno.Include(n => n.Nadmetanje).FirstOrDefault(j => j.JavnoNadmetanjeId == id);
        }

        public void InsertJavno(Javno javno)
        {
            _databaseContext.Javno.Add(javno);
        }

        public void UpdateJavno(Javno javno)
        {
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public void DeleteJavno(Guid id)
        {
            _databaseContext.Javno.Remove(GetJavno(id));
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }
    }
}
