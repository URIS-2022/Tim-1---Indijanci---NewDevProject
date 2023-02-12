using Licitacija.Services.ZalbaAPI.Entities;

namespace Licitacija.Services.ZalbaAPI.Repositories.Interfaces
{
    public interface IZalbaRepository
    {
        List<Zalba> GetAll();
        Zalba GetZalba(Guid id);
        void InsertZalba(Zalba zalba);
        void DeleteZalba(Guid id);
        void UpdateZalba(Zalba zalba);
        bool Save();
    }
}
