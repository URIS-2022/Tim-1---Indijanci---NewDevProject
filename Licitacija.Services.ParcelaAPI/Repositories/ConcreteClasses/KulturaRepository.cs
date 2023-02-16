using Licitacija.Services.ParcelaAPI.DbContexts;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;

namespace Licitacija.Services.ParcelaAPI.Repositories.ConcreteClasses
{
    public class KulturaRepository : IKulturaRepository
    {
        private readonly DataContext _dataContext;

        public KulturaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteKultura(Guid id)
        {
            _dataContext.Remove(GetKultura(id));
        }

        public List<Kultura> GetAll()
        {
            return _dataContext.Kulture.ToList();
        }

        public Kultura GetKultura(Guid id)
        {
            return _dataContext.Kulture.FirstOrDefault(e => e.KulturaId == id);
        }

        public void InsertKultura(Kultura kultura)
        {
            _dataContext.Add(kultura);
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public void UpdateKultura(Kultura kultura)
        {
            //Implementacija Update metode nije potrebna jer EF prati izmene i automatski pri primeni Save() metode vrsi izmene
        }
    }
}