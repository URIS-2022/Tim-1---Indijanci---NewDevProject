using Licitacija.Services.ParcelaAPI.DbContexts;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;

namespace Licitacija.Services.ParcelaAPI.Repositories.ConcreteClasses
{
    public class KlasaRepository : IKlasaRepository
    {
        private readonly DataContext _dataContext;

        public KlasaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteKlasa(Guid id)
        {
            _dataContext.Remove(GetKlasa(id));
        }

        public List<Klasa> GetAll()
        {
            return _dataContext.Klase.ToList();
        }

        public Klasa GetKlasa(Guid id)
        {
            return _dataContext.Klase.FirstOrDefault(e => e.KlasaId == id);
        }

        public void InsertKlasa(Klasa klasa)
        {
            _dataContext.Add(klasa);
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public void UpdateKlasa(Klasa klasa)
        {
            //Implementacija Update metode nije potrebna jer EF prati izmene i automatski pri primeni Save() metode vrsi izmene
        }
    }
}
