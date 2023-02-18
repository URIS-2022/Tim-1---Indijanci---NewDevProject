using Licitacija.Services.ParcelaAPI.DbContexts;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.ParcelaAPI.Repositories.ConcreteClasses
{
    public class DeoParceleRepository : IDeoParceleRepository
    {
        private readonly DataContext _dataContext;

        public DeoParceleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteDeoParcele(Guid id)
        {
            _dataContext.Remove(GetDeoParcele(id));
        }

        public List<DeoParcele> GetAll()
        {
            return _dataContext.DeloviParcele.Include(i => i.Parcela).Include(i => i.Parcela.Klasa).Include(i => i.Parcela.Kultura)
                .Include(i => i.Parcela.OblikSvojine).Include(i => i.Parcela.Odvodnjavanje).Include(i => i.Parcela.Obradivost)
                .Include(i => i.Parcela.KatastarskaOpstina).ToList();
        }

        public DeoParcele GetDeoParcele(Guid id)
        {
            return _dataContext.DeloviParcele.Include(i => i.Parcela).Include(i => i.Parcela.Klasa).Include(i => i.Parcela.Kultura)
                .Include(i => i.Parcela.OblikSvojine).Include(i => i.Parcela.Odvodnjavanje).Include(i => i.Parcela.Obradivost)
                .Include(i => i.Parcela.KatastarskaOpstina).FirstOrDefault(e => e.DeoParceleId == id);
        }

        public void InsertDeoParcele(DeoParcele deoParcele)
        {
            _dataContext.Add(deoParcele);
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public void UpdateDeoParcele(DeoParcele deoParcele)
        {
            //Implementacija Update metode nije potrebna jer EF prati izmene i automatski pri primeni Save() metode vrsi izmene
        }
    }
}
