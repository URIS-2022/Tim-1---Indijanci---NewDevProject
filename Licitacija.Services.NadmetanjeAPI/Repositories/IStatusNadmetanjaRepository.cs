using Licitacija.Services.NadmetanjeAPI.Entities;

namespace Licitacija.Services.NadmetanjeAPI.Repositories
{
    public interface IStatusNadmetanjaRepository
    {
        List<StatusNadmetanja>GetAll();
        StatusNadmetanja GetStatusNadmetanja(Guid id);
        void InsertStatusNadmetanja(StatusNadmetanja statusNadmetanja);
        void DeleteStatusNadmetanja(Guid id);
        void UpdateStatusNadmetanja(StatusNadmetanja statusNadmetanja);
        bool Save();
    }
}
