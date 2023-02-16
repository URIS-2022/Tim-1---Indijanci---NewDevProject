using Licitacija.Services.NadmetanjeKupacAPI.Entities;

namespace Licitacija.Services.NadmetanjeKupacAPI.Repositories.Interfaces
{
    public interface INadmetanjeKupacRepository
    {
        List<NadmetanjeKupacEntity> GetAll();
        NadmetanjeKupacEntity GetNadmetanjeKupac(Guid id);
        void InsertNadmetanjeKupac(NadmetanjeKupacEntity nadmetanjeKupac);
        void DeleteNadmetanjeKupac(Guid id);
        void UpdateNadmetanjeKupac(NadmetanjeKupacEntity nadmetanjeKupac);
        bool Save();
    }
}
