using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.UplataAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.NadmetanjeAPI.Repositories
{
    public class OtvaranjePonudaRepository : IOtvaranjePonudaRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OtvaranjePonudaRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<OtvaranjePonuda> GetAll()
        {
            return _databaseContext.OtvaranjePonuda.Include(n => n.Nadmetanje).ToList();
        }

        public OtvaranjePonuda GetOtvaranjePonuda(Guid id)
        {
            return _databaseContext.OtvaranjePonuda.Include(n => n.Nadmetanje).FirstOrDefault(op => op.OtvaranjePonudaId == id);
        }

        public void InsertOtvaranjePonuda(OtvaranjePonuda otvaranjePonuda)
        {
            _databaseContext.OtvaranjePonuda.Add(otvaranjePonuda);
        }

        public void UpdateOtvaranjePonuda(OtvaranjePonuda otvaranjePonuda)
        {
            //EF prati izmene i automatski pri primeni Save() metode vrsi update, zbog toga nije neophodno implementirati Update
        }

        public void DeleteOtvaranjePonuda(Guid id)
        {
            _databaseContext.OtvaranjePonuda.Remove(GetOtvaranjePonuda(id));
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }

        public OtvaranjePonuda GetOtvaranjePonudaBasic(Guid id)
        {
            return _databaseContext.OtvaranjePonuda.FirstOrDefault(op => op.OtvaranjePonudaId == id);
        }
    }
}
