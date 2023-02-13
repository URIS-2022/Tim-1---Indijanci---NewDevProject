using Licitacija.Services.ParcelaAPI.DbContexts;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;

namespace Licitacija.Services.ParcelaAPI.Repositories.ConcreteClasses
{
    public class ZasticenaZonaRepository : IZasticenaZonaRepository
    {
        private readonly DataContext _dataContext;

        public ZasticenaZonaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteZasticenaZona(Guid id)
        {
            _dataContext.Remove(GetZasticenaZona(id));
        }

        public List<ZasticenaZona> GetAll()
        {
            return _dataContext.ZasticeneZone.ToList();
        }

        public ZasticenaZona GetZasticenaZona(Guid id)
        {
            return _dataContext.ZasticeneZone.FirstOrDefault(e => e.ZZonaId == id);
        }

        public void InsertZasticenaZona(ZasticenaZona zasticenaZona)
        {
            _dataContext.Add(zasticenaZona);
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public void UpdateZasticenaZona(ZasticenaZona zasticenaZona)
        {
            //Implementacija Update metode nije potrebna jer EF prati izmene i automatski pri primeni Save() metode vrsi izmene
        }
    }
}
