using AutoMapper;
using Licitacija.Services.ZalbaAPI.DbContexts;
using Licitacija.Services.ZalbaAPI.Entities;
using Licitacija.Services.ZalbaAPI.Repositories.Interfaces;

namespace Licitacija.Services.ZalbaAPI.Repositories.ConcreteClasses
{
    public class TipZalbeRepository : ITipZalbeRepository
    {
        private readonly DataContext _databaseContext;

        public TipZalbeRepository(DataContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<TipZalbe> GetAll()
        {
            return _databaseContext.TipoviZalbi.ToList();
        }

        public TipZalbe GetTipZalbe(Guid id)
        {
            return _databaseContext.TipoviZalbi.FirstOrDefault(e => e.TipZalbeId == id);
        }

        public void InsertTipZalbe(TipZalbe tipZalbe)
        {
            _databaseContext.Add(tipZalbe);
        }

        public void DeleteTipZalbe(Guid id)
        {
            _databaseContext.Remove(GetTipZalbe(id));
        }

        public void UpdateTipZalbe(TipZalbe tipZalbe)
        {
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }
    }
}
