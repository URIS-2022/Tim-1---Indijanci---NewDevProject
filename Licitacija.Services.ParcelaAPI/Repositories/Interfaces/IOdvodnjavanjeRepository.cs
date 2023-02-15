using Licitacija.Services.ParcelaAPI.Entities;

namespace Licitacija.Services.ParcelaAPI.Repositories.Interfaces
{
    public interface IOdvodnjavanjeRepository
    {
        List<Odvodnjavanje> GetAll();
        Odvodnjavanje GetOdvodnjavanje(Guid id);
        void InsertOdvodnjavanje(Odvodnjavanje odvodnjavanje);
        void DeleteOdvodnjavanje(Guid id);
        void UpdateOdvodnjavanje(Odvodnjavanje odvodnjavanje);
        bool Save();
    }
}
