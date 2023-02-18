using Licitacija.Services.EtapaAPI.Entities;

namespace Licitacija.Services.EtapaAPI.Repositories.Interfaces
{
    public interface IEtapaRepository
    {
        List<Etapa> GetAll();
        Etapa GetEtapa (Guid id);
        Etapa GetEtapaBasicInfo(Guid id);
        void InsertEtapa(Etapa etapa);
        void DeleteEtapa(Guid id);
        void UpdateEtapa(Etapa etapa);
        bool Save();
    }
}
