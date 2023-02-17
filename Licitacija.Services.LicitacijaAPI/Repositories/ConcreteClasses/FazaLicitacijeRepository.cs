using Licitacija.Services.LicitacijaAPI.DbContexts;
using Licitacija.Services.LicitacijaAPI.Entities;
using Licitacija.Services.LicitacijaAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.LicitacijaAPI.Repositories.ConcreteClasses
{
    public class FazaLicitacijeRepository : IFazaLicitacije
    {
        private readonly DataContext _databaseContext;
        public FazaLicitacijeRepository(DataContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void DeleteFazaLicitacije(Guid id)
        {
            _databaseContext.Remove(GetFazaLicitacije(id));
        }

        public List<FazaLicitacije> GetAll()
        {
            return _databaseContext.FazaLicitacije.Include(i => i.Licitacija).ToList();
        }

        public FazaLicitacije GetFazaLicitacije(Guid id)
        {
            return _databaseContext.FazaLicitacije.Include(i => i.Licitacija).FirstOrDefault(e => e.FazaId == id);
        }

        public void InsertFazaLicitacije(FazaLicitacije fazaLicitacije)
        {
            _databaseContext.Add(fazaLicitacije);
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }

        public void UpdateFazaLicitacije(FazaLicitacije fazaLicitacije)
        {
            throw new NotImplementedException();
        }

        public FazaLicitacije GetFazaLicitacijeBasic(Guid id)
        {
            return _databaseContext.FazaLicitacije.FirstOrDefault(e => e.FazaId == id);
        }
    }
}
