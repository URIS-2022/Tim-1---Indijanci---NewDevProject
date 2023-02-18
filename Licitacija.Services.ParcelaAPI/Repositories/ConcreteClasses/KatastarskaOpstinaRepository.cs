using Licitacija.Services.ParcelaAPI.DbContexts;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;

namespace Licitacija.Services.ParcelaAPI.Repositories.ConcreteClasses
{
    public class KatastarskaOpstinaRepository : IKatastarskaOpstinaRepository
    {
        private readonly DataContext _dataContext;

        public KatastarskaOpstinaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteKatastarskaOpstina(Guid id)
        {
            _dataContext.Remove(GetKatastarskaOpstina(id));
        }

        public List<KatastarskaOpstina> GetAll()
        {
            return _dataContext.KatastarskeOpstine.ToList();
        }

        public KatastarskaOpstina GetKatastarskaOpstina(Guid id)
        {
            return _dataContext.KatastarskeOpstine.FirstOrDefault(e => e.KatOpstinaId == id);
        }

        public KatastarskaOpstina GetKatastarskaOpstinaBasicInfo(Guid id)
        {
            return _dataContext.KatastarskeOpstine.FirstOrDefault(e => e.KatOpstinaId == id);
        }

        public void InsertKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina)
        {
            _dataContext.Add(katastarskaOpstina);
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public void UpdateKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina)
        {
            //Implementacija Update metode nije potrebna jer EF prati izmene i automatski pri primeni Save() metode vrsi izmene
        }
    }
}
