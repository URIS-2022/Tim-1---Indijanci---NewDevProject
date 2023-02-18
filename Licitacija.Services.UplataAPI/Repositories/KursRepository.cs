using Licitacija.Services.UplataAPI.Entities;

namespace Licitacija.Services.UplataAPI.Repositories
{
    public class KursRepository : IKursRepository
    {
        private readonly DatabaseContext _databaseContext;

        public KursRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Kurs> GetAll()
        {
            return _databaseContext.Kurs.ToList();
        }

        public Kurs GetKurs(Guid id)
        {
            return _databaseContext.Kurs.FirstOrDefault(e => e.KursId == id);
        }

        public void InsertKurs(Kurs kurs)
        {
            _databaseContext.Add(kurs);
        }

        public void DeleteKurs(Guid id)
        {
            _databaseContext.Remove(GetKurs(id));
        }

        public void UpdateKurs(Kurs kurs)
        {
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }
    }
}
