using Licitacija.Services.LicitacijaAPI.Entities;

namespace Licitacija.Services.LicitacijaAPI.Repositories.Interface
{
    public interface IFazaLicitacije
    {
        List<FazaLicitacije> GetAll();
        FazaLicitacije GetFazaLicitacije(Guid id);
        void InsertFazaLicitacije(FazaLicitacije fazalicitacije);
        void DeleteFazaLicitacije(Guid id);
        void UpdateFazaLicitacije(FazaLicitacije fazaLicitacije);
        FazaLicitacije GetFazaLicitacijeBasic(Guid id);
        bool Save();
    }
}
