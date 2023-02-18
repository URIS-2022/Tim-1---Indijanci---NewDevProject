using Licitacija.Services.ParcelaAPI.Entities;

namespace Licitacija.Services.ParcelaAPI.Repositories.Interfaces
{
    public interface IPovrsinaRepository
    {
        List<Povrsina> GetAll();
        Povrsina GetPovrsina(Guid id);
        void InsertPovrsina(Povrsina povrsina);
        void DeletePovrsina(Guid id);
        void UpdatePovrsina(Povrsina povrsina);
        bool Save();
    }
}
