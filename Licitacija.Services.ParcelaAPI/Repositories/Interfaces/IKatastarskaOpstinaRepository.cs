using Licitacija.Services.ParcelaAPI.Entities;

namespace Licitacija.Services.ParcelaAPI.Repositories.Interfaces
{
    public interface IKatastarskaOpstinaRepository
    {
        List<KatastarskaOpstina> GetAll();
        KatastarskaOpstina GetKatastarskaOpstina(Guid id);
        void InsertKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina);
        void DeleteKatastarskaOpstina(Guid id);
        void UpdateKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina);
        bool Save();
    }
}
