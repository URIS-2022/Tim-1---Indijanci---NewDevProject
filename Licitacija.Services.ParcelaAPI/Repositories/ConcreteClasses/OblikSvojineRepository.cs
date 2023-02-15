using Licitacija.Services.ParcelaAPI.DbContexts;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;

namespace Licitacija.Services.ParcelaAPI.Repositories.ConcreteClasses
{
    public class OblikSvojineRepository : IOblikSvojineRepository
    {
        private readonly DataContext _dataContext;

        public OblikSvojineRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteOblikSvojine(Guid id)
        {
            _dataContext.Remove(GetOblikSvojine(id));
        }

        public List<OblikSvojine> GetAll()
        {
            return _dataContext.ObliciSvojina.ToList();
        }

        public OblikSvojine GetOblikSvojine(Guid id)
        {
            return _dataContext.ObliciSvojina.FirstOrDefault(e => e.OblikSvojineId == id);
        }

        public void InsertOblikSvojine(OblikSvojine oblikSvojine)
        {
            _dataContext.Add(oblikSvojine);
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public void UpdateOblikSvojine(OblikSvojine oblikSvojine)
        {
            //Implementacija Update metode nije potrebna jer EF prati izmene i automatski pri primeni Save() metode vrsi izmene
        }
    }
}
