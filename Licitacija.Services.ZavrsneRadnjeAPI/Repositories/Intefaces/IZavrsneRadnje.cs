using Licitacija.Services.ZavrsneRadnjeAPI.Entities;

namespace Licitacija.Services.ZavrsneRadnjeAPI.Repositories.ConcreteClasses.Interfaces
{
    public interface IZavrsneRadnje
    {
        List<ZavrsneRadnje> GetAll();
        ZavrsneRadnje GetZavrsneRadnje(Guid id);
        void InsertZavrsneRadnje(ZavrsneRadnje zavrsneRadnje);
        void DeleteZavrsneRadnje(Guid id);
        void UpdateZavrsneRadnje(ZavrsneRadnje zavrsneRadnje);
        bool Save();
    }
}