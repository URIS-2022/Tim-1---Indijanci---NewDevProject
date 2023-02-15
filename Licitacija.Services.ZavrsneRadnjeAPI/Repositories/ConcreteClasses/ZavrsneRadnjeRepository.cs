using Licitacija.Services.ZavrsneRadnjeAPI.DbContexts;
using Licitacija.Services.ZavrsneRadnjeAPI.Entities;
using Licitacija.Services.ZavrsneRadnjeAPI.Repositories.ConcreteClasses.Interfaces;

namespace Licitacija.Services.ZavrsneRadnjeAPI.Repositories.ConcreteClasses
{
    public class ZavrsneRadnjeRepository : IZavrsneRadnje
    {
        private readonly DataContext _databaseContext;

        public ZavrsneRadnjeRepository(DataContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void DeleteZavrsneRadnje(Guid id)
        {
            _databaseContext.Remove(GetZavrsneRadnje(id));
        }

        public List<ZavrsneRadnje> GetAll()
        {
            return _databaseContext.ZavrsneRadnje.ToList();
        }

        public ZavrsneRadnje GetZavrsneRadnje(Guid id)
        {
            return _databaseContext.ZavrsneRadnje.FirstOrDefault(e => e.ZavrsnaRadnjaId == id);
        }

        public void InsertZavrsneRadnje(ZavrsneRadnje zavrsneRadnje)
        {
            _databaseContext.Add(zavrsneRadnje);
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }

        public void UpdateZavrsneRadnje(ZavrsneRadnje zavrsneRadnje)
        {
            
        }
    }
}
