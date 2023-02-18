using Licitacija.Services.NadmetanjeKupacAPI.Entities;

namespace Licitacija.Services.NadmetanjeKupacAPI.Repositories.Interfaces
{
    public interface IOvlascenoLiceRepository
    {
        List<OvlascenoLice> GetAll();
        OvlascenoLice GetOvlascenoLice(Guid id);
        void InsertOvlascenoLice(OvlascenoLice ovlascenoLice);
        void DeleteOvlascenoLice(Guid id);
        void UpdateOvlascenoLice(OvlascenoLice ovlascenoLice);
        bool Save();
    }
}
