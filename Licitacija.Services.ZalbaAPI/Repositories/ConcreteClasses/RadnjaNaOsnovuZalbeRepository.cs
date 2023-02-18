using AutoMapper;
using Licitacija.Services.ZalbaAPI.DbContexts;
using Licitacija.Services.ZalbaAPI.Entities;
using Licitacija.Services.ZalbaAPI.Repositories.Interfaces;

namespace Licitacija.Services.ZalbaAPI.Repositories.ConcreteClasses
{
    public class RadnjaNaOsnovuZalbeRepository : IRadnjaNaOsnovuZalbeRepository
    {
        private readonly DataContext _databaseContext;

        public RadnjaNaOsnovuZalbeRepository(DataContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<RadnjaNaOsnovuZalbe> GetAll()
        {
            return _databaseContext.RadnjeNaOsnovuZalbe.ToList();
        }

        public RadnjaNaOsnovuZalbe GetRadnjaNaOsnovuZalbe(Guid id)
        {
            return _databaseContext.RadnjeNaOsnovuZalbe.FirstOrDefault(e => e.RadnjaId == id);
        }

        public void InsertRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe)
        {
            _databaseContext.Add(radnjaNaOsnovuZalbe);
        }

        public void DeleteRadnjaNaOsnovuZalbe(Guid id)
        {
            _databaseContext.Remove(GetRadnjaNaOsnovuZalbe(id));
        }

        public void UpdateRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe)
        {
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }
    }
}
