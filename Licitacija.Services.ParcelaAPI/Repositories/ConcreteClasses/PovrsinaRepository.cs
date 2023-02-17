using Licitacija.Services.ParcelaAPI.DbContexts;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.ParcelaAPI.Repositories.ConcreteClasses
{
    public class PovrsinaRepository : IPovrsinaRepository
    {
        private readonly DataContext _dataContext;

        public PovrsinaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeletePovrsina(Guid id)
        {
            _dataContext.Remove(GetPovrsina(id));
        }

        public List<Povrsina> GetAll()
        {
            return _dataContext.Povrsine.Include(i => i.Parcela).Include(i => i.Parcela.Klasa).Include(i => i.Parcela.Kultura)
                .Include(i => i.Parcela.OblikSvojine).Include(i => i.Parcela.Odvodnjavanje).Include(i => i.Parcela.Obradivost)
                .Include(i => i.Parcela.KatastarskaOpstina).Include(i => i.ZasticenaZona).ToList();
        }

        public Povrsina GetPovrsina(Guid id)
        {
            return _dataContext.Povrsine.Include(i => i.Parcela).Include(i => i.Parcela.Klasa).Include(i => i.Parcela.Kultura)
                .Include(i => i.Parcela.OblikSvojine).Include(i => i.Parcela.Odvodnjavanje).Include(i => i.Parcela.Obradivost)
                .Include(i => i.Parcela.KatastarskaOpstina).Include(i => i.ZasticenaZona).FirstOrDefault(e => e.PovrsinaId == id);
        }

        public void InsertPovrsina(Povrsina povrsina)
        {
            _dataContext.Add(povrsina);
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public void UpdatePovrsina(Povrsina povrsina)
        {
            //Implementacija Update metode nije potrebna jer EF prati izmene i automatski pri primeni Save() metode vrsi izmene
        }
    }
}
