using Licitacija.Services.EtapaAPI.DbContexts;
using Licitacija.Services.EtapaAPI.Entities;
using Licitacija.Services.EtapaAPI.Repositories.Interfaces;

namespace Licitacija.Services.EtapaAPI.Repositories.ConcreteClasses
{
    public class EtapaRepository : IEtapaRepository
    {
        private readonly DataContext _dataContext;

        public EtapaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteEtapa(Guid id)
        {
            _dataContext.Remove(GetEtapa(id));
        }

        public List<Etapa> GetAll()
        {
            return _dataContext.Etape.ToList();
        }

        public Etapa GetEtapa(Guid id)
        {
            return _dataContext.Etape.FirstOrDefault(e => e.EtapaId == id);
        }

        public Etapa GetEtapaBasicInfo(Guid id)
        {
            return _dataContext.Etape.FirstOrDefault(e => e.EtapaId == id);
        }

        public void InsertEtapa(Etapa etapa)
        {
            _dataContext.Add(etapa);
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public void UpdateEtapa(Etapa etapa)
        {
            //Implementacija Update metode nije potrebna jer EF prati izmene i automatski pri primeni Save() metode vrsi izmene
        }
    }
}
