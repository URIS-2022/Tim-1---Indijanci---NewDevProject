using AutoMapper;
using Licitacija.Services.UplataAPI.Entities;

namespace Licitacija.Services.UplataAPI.Repositories
{
    public class KursRepository : IKursRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public KursRepository(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public List<Kurs> GetAll()
        {
            return _databaseContext.Kurs.ToList();
        }

        public Kurs GetKurs(Guid id)
        {
            return _databaseContext.Kurs.FirstOrDefault(e => e.KursId == id);
        }

        public void InsertKurs(Kurs kurs)
        {
            _databaseContext.Add(kurs);
        }

        public void DeleteKurs(Guid id)
        {
            _databaseContext.Remove(GetKurs(id));
        }

        /*public void UpdateKurs(Kurs kurs)
        {
            
        }*/

        public bool Save()
        {
            return _databaseContext.SaveChanges() > 0;
        }
    }
}
