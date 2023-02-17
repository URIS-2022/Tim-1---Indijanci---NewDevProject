using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.UplataAPI.Entities;

namespace Licitacija.Services.NadmetanjeAPI.Repositories
{
    public class StatusNadmetanjaRepository : IStatusNadmetanjaRepository
    {
        private readonly DatabaseContext _databaseContext;

        public StatusNadmetanjaRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<StatusNadmetanja> GetAll()
        {
            return _databaseContext.StatusNadmetanja.ToList();
        }

        public StatusNadmetanja GetStatusNadmetanja(Guid id)
        {
            return _databaseContext.StatusNadmetanja.FirstOrDefault(sn => sn.StatusNadmetanjaId == id);
        }

        public void InsertStatusNadmetanja(StatusNadmetanja statusNadmetanja)
        {
            _databaseContext.Add(statusNadmetanja);
        }

        public void DeleteStatusNadmetanja(Guid id)
        {
            _databaseContext.Remove(GetStatusNadmetanja(id));
        }

        public void UpdateStatusNadmetanja(StatusNadmetanja statusNadmetanja)
        {
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }


    }
}
