using AutoMapper;
using Licitacija.Services.UplataAPI.Entities;
using Licitacija.Services.UplataAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Licitacija.Services.UplataAPI.Repositories
{
    public class UplataRepository : IUplataRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public UplataRepository(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public List<Uplata> GetAll()
        {
            return _databaseContext.Uplata.Include(i => i.Kurs).ToList();
        }

        public Uplata GetUplata(Guid id)
        {
            return _databaseContext.Uplata.Include(i => i.Kurs).FirstOrDefault(e => e.UplataId == id);
        }

        public void InsertUplata(Uplata uplata)
        {
            _databaseContext.Add(uplata);
        }

        public void DeleteUplata(Guid id)
        {
            _databaseContext.Remove(GetUplata(id));
        }

        public void UpdateUplata(Uplata uplata)
        {
            
        }

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }

    }
}
