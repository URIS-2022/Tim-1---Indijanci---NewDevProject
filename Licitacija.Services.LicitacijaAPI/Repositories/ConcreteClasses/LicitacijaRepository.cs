using Licitacija.Services.LicitacijaAPI.DbContexts;
using Licitacija.Services.LicitacijaAPI.Entities;
using Licitacija.Services.LicitacijaAPI.Repositories.Interface;

namespace Licitacija.Services.LicitacijaAPI.Repositories.ConcreteClasses
{
    public class LicitacijaRepository : ILicitacija
    {
        private readonly DataContext _databaseContext;
        public LicitacijaRepository(DataContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void DeleteLicitacija(Guid id)
        {
            _databaseContext.Remove(GetLicitacija(id));
        }

        public List<LicitacijaEntity> GetAll()
        {
            return _databaseContext.Licitacija.ToList();
        }

        public LicitacijaEntity GetLicitacija(Guid id)
        {
            return _databaseContext.Licitacija.FirstOrDefault(e => e.LicitacijaId == id);
        }

        public void InsertLicitacija(LicitacijaEntity licitacija)
        {
            _databaseContext.Add(licitacija);
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }

        public void UpdateLicitacija(LicitacijaEntity licitacija)
        {
            throw new NotImplementedException();
        }

        public LicitacijaEntity GetLicitacijaBasic(Guid id)
        {
            return _databaseContext.Licitacija.FirstOrDefault(e => e.LicitacijaId == id);
        }
    }
}
