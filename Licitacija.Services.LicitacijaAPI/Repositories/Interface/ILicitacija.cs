using Licitacija.Services.LicitacijaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.LicitacijaAPI.Repositories.Interface
{
    public interface ILicitacija
    {
        List<LicitacijaEntity> GetAll();
        LicitacijaEntity GetLicitacija(Guid id);
        void InsertLicitacija(LicitacijaEntity licitacija);
        void DeleteLicitacija(Guid id);
        void UpdateLicitacija(LicitacijaEntity licitacija);
        LicitacijaEntity GetLicitacijaBasic(Guid id);
        bool Save();
    }
}
