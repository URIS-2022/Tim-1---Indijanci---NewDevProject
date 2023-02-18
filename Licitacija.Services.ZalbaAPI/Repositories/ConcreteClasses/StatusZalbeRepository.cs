using AutoMapper;
using Licitacija.Services.ZalbaAPI.DbContexts;
using Licitacija.Services.ZalbaAPI.Entities;
using Licitacija.Services.ZalbaAPI.Repositories.Interfaces;

namespace Licitacija.Services.ZalbaAPI.Repositories.ConcreteClasses
{
    public class StatusZalbeRepository : IStatusZalbeRepository
    { 
        private readonly DataContext _databaseContext;

        public StatusZalbeRepository(DataContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<StatusZalbe> GetAll()
        {
            return _databaseContext.StatusiZalbi.ToList();
        }

        public StatusZalbe GetStatusZalbe(Guid id)
        {
            return _databaseContext.StatusiZalbi.FirstOrDefault(e => e.StatusZalbeId == id);
        }

        public void InsertStatusZalbe(StatusZalbe statusZalbe)
        {
            _databaseContext.Add(statusZalbe);
        }

        public void DeleteStatusZalbe(Guid id)
        {
            _databaseContext.Remove(GetStatusZalbe(id));
        }

        public void UpdateStatusZalbe(StatusZalbe statusZalbe)
        {
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }
    }
}
