using Licitacija.Services.NadmetanjeAPI.Entities;

namespace Licitacija.Services.NadmetanjeAPI.Repositories
{
    public interface IJavnoRepository
    {
        List<Javno> GetAll();
        Javno GetJavno(Guid id);
        void InsertJavno(Javno javno);
        void DeleteJavno(Guid id);
        void UpdateJavno(Javno javno);
        bool Save();
    }
}
