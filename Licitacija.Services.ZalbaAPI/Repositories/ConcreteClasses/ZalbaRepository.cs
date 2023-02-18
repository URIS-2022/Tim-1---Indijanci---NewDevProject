using AutoMapper;
using Licitacija.Services.ZalbaAPI.DbContexts;
using Licitacija.Services.ZalbaAPI.Entities;
using Licitacija.Services.ZalbaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.ZalbaAPI.Repositories.ConcreteClasses
{
    public class ZalbaRepository : IZalbaRepository
    {
        private readonly DataContext _databaseContext;

        public ZalbaRepository(DataContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Zalba> GetAll()
        {
            return _databaseContext.Zalbe.Include(i => i.TipZalbe)
                .Include(i => i.StatusZalbe).Include(i => i.RadnjaNaOsnovuZalbe).ToList();
        }

        public Zalba GetZalba(Guid id)
        {
            return _databaseContext.Zalbe.Include(i => i.TipZalbe)
                .Include(i => i.StatusZalbe).Include(i => i.RadnjaNaOsnovuZalbe).FirstOrDefault(e => e.ZalbaId == id);
        }

        public void InsertZalba(Zalba zalba)
        {
            _databaseContext.Add(zalba);
        }

        public void DeleteZalba(Guid id)
        {
            _databaseContext.Remove(GetZalba(id));
        }

        public void UpdateZalba(Zalba zalba)
        {

        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }
    }
}
