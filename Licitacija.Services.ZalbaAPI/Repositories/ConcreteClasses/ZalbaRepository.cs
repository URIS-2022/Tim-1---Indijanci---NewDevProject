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
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Provera da li dati podatak postoji u bazi, ako postoji vrati false, ako ne onda true
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsValidZalba(Zalba zalba)
        {
            var zalbe = await _databaseContext.Zalbe.Where(z => z.BrojResenja == zalba.BrojResenja || z.BrojNadmetanja == zalba.BrojNadmetanja).ToListAsync();

            return zalbe.Count == 0;
        }
    }
}
