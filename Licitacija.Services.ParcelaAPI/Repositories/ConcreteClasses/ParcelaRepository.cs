using Licitacija.Services.ParcelaAPI.DbContexts;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.ParcelaAPI.Repositories.ConcreteClasses
{
    public class ParcelaRepository : IParcelaRepository
    {
        private readonly DataContext _dataContext;

        public ParcelaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteParcela(Guid id)
        {
            _dataContext.Remove(GetParcela(id));
        }

        public List<Parcela> GetAll()
        {
            return _dataContext.Parcele.Include(i => i.Odvodnjavanje).Include(i => i.Obradivost).
                Include(i => i.OblikSvojine).Include(i => i.Kultura).Include(i => i.Klasa).Include(i => i.KatastarskaOpstina).ToList();
        }

        public Parcela GetParcela(Guid id)
        {
            return _dataContext.Parcele.Include(i => i.Odvodnjavanje).Include(i => i.Obradivost).
                Include(i => i.OblikSvojine).Include(i => i.Kultura).Include(i => i.Klasa).Include(i => i.KatastarskaOpstina).FirstOrDefault(e => e.ParcelaId == id);
        }

        public void InsertParcela(Parcela parcela)
        {
            _dataContext.Add(parcela);
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public void UpdateParcela(Parcela parcela)
        {
            //Implementacija Update metode nije potrebna jer EF prati izmene i automatski pri primeni Save() metode vrsi izmene
        }
    }
}
