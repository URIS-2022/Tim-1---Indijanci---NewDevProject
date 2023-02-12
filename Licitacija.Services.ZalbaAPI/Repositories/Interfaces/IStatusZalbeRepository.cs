using Licitacija.Services.ZalbaAPI.Entities;

namespace Licitacija.Services.ZalbaAPI.Repositories.Interfaces
{
    public interface IStatusZalbeRepository
    {
        List<StatusZalbe> GetAll();
        StatusZalbe GetStatusZalbe(Guid id);
        void InsertStatusZalbe(StatusZalbe statusZalbe);
        void DeleteStatusZalbe(Guid id);
        void UpdateStatusZalbe(StatusZalbe statusZalbe);
        bool Save();
    }
}
