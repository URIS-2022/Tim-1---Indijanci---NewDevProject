using Licitacija.Services.ParcelaAPI.DbContexts;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;

namespace Licitacija.Services.ParcelaAPI.Repositories.ConcreteClasses
{
    public class OdvodnjavanjeRepository : IOdvodnjavanjeRepository
    {
        private readonly DataContext _dataContext;

        public OdvodnjavanjeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteOdvodnjavanje(Guid id)
        {
            _dataContext.Remove(GetOdvodnjavanje(id));
        }

        public List<Odvodnjavanje> GetAll()
        {
            return _dataContext.Odvodnjavanja.ToList();
        }

        public Odvodnjavanje GetOdvodnjavanje(Guid id)
        {
            return _dataContext.Odvodnjavanja.FirstOrDefault(e => e.OdvodnjavanjeId == id);
        }

        public void InsertOdvodnjavanje(Odvodnjavanje odvodnjavanje)
        {
            _dataContext.Add(odvodnjavanje);
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public void UpdateOdvodnjavanje(Odvodnjavanje odvodnjavanje)
        {
            //Implementacija Update metode nije potrebna jer EF prati izmene i automatski pri primeni Save() metode vrsi izmene
        }
    }
}
