using Licitacija.Services.NadmetanjeAPI.Entities;

namespace Licitacija.Services.NadmetanjeAPI.Repositories
{
    public interface INadmetanjeRepository
    {
        List<Nadmetanje> GetAll();
        Nadmetanje GetNadmetanje(Guid id);
        Nadmetanje GetNadmetanjeBasic(Guid id);
        void InsertNadmetanje(Nadmetanje nadmetanje);
        void DeleteNadmetanje(Guid id);
        void UpdateNadmetanje(Nadmetanje nadmetanje);
        bool Save();
    }
}
