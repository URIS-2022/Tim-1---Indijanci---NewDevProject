using Licitacija.Services.ParcelaAPI.Entities;

namespace Licitacija.Services.ParcelaAPI.Repositories.Interfaces
{
    public interface IDeoParceleRepository
    {
        List<DeoParcele> GetAll();
        DeoParcele GetDeoParcele(Guid id);
        void InsertDeoParcele(DeoParcele deoParcele);
        void DeleteDeoParcele(Guid id);
        void UpdateDeoParcele(DeoParcele deoParcele);
        bool Save();
    }
}
