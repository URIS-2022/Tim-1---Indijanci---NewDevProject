using Licitacija.Services.NadmetanjeAPI.Entities;

namespace Licitacija.Services.NadmetanjeAPI.Repositories
{
    public interface IOtvaranjePonudaRepository
    {
        List<OtvaranjePonuda> GetAll();
        OtvaranjePonuda GetOtvaranjePonuda(Guid id);
        OtvaranjePonuda GetOtvaranjePonudaBasic(Guid id);
        void InsertOtvaranjePonuda(OtvaranjePonuda otvaranjePonuda);
        void DeleteOtvaranjePonuda(Guid id);
        void UpdateOtvaranjePonuda(OtvaranjePonuda otvaranjePonuda);
        bool Save();
    }
}
