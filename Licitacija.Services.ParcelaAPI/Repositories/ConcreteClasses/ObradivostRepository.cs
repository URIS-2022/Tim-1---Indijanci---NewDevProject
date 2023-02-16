using Licitacija.Services.ParcelaAPI.DbContexts;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;

namespace Licitacija.Services.ParcelaAPI.Repositories.ConcreteClasses
{
    public class ObradivostRepository : IObradivostRepository
    {
        private readonly DataContext _dataContext;

        public ObradivostRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteObradivost(Guid id)
        {
            _dataContext.Remove(GetObradivost(id));
        }

        public List<Obradivost> GetAll()
        {
            return _dataContext.Obradivosti.ToList();
        }

        public Obradivost GetObradivost(Guid id)
        {
            return _dataContext.Obradivosti.FirstOrDefault(e => e.ObradivostId == id);
        }

        public void InsertObradivost(Obradivost obradivost)
        {
            _dataContext.Add(obradivost);
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public void UpdateObradivost(Obradivost obradivost)
        {
            //Implementacija Update metode nije potrebna jer EF prati izmene i automatski pri primeni Save() metode vrsi izmene
        }
    }
}
