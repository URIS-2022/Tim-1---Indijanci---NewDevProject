using Licitacija.Services.ZalbaAPI.Entities;

namespace Licitacija.Services.ZalbaAPI.Repositories.Interfaces
{
    public interface ITipZalbeRepository
    {
        List<TipZalbe> GetAll();
        TipZalbe GetTipZalbe(Guid id);
        void InsertTipZalbe(TipZalbe tipZalbe);
        void DeleteTipZalbe(Guid id);
        void UpdateTipZalbe(TipZalbe tipZalbe);
        bool Save();
    }
}
