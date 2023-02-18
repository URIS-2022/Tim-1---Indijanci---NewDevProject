using Licitacija.Services.KomisijaAPI.DbConexts;
using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.KomisijaDtos;
using Licitacija.Services.KomisijaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.KomisijaAPI.Repositories.Repos
{
    public class KomisijaRepository : IKomisijaRepository
    {

        private readonly DataContext _context;

        public KomisijaRepository(DataContext context)
        {
            _context = context;
        }

        public Komisija AddKomisija(AddKomisijaDto addKomisija)
        {
            var komisija = new Komisija()
            {
                KomisijaId = Guid.NewGuid(),
                TipKomisijeId = addKomisija.TipKomisijeId,
                PredradnjaNadmetanjaId = addKomisija.PredradnjaNadmetanjaId,
                ProgramId = addKomisija.ProgramId
            };

            _context.Komisija.Add(komisija);

            return komisija;
        }

        public async Task<bool> DeleteKomisijaById(Guid id)
        {
            var komisija = await GetKomisijaById(id);

            if (komisija == null)
            {
                return false;
            }

            _context.Remove(komisija);

            return true;
        }

        public async Task<List<Komisija>> GetAllKomisije()
        {
            return await _context.Komisija.Include(k => k.TipKomisije).ToListAsync();
        }

        public async Task<Komisija?> GetKomisijaById(Guid id)
        {
            return await _context.Komisija.Include(k => k.TipKomisije).Where(k => k.KomisijaId == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Komisija?> UpdateKomisija(UpdateKomisijaDto updateKomisija)
        {
            Komisija? komisija = await _context.Komisija.FirstOrDefaultAsync(k => k.KomisijaId== updateKomisija.KomisijaId);

            if (komisija != null)
            {
                komisija.PredradnjaNadmetanjaId = updateKomisija.PredradnjaNadmetanjaId;
                komisija.ProgramId = updateKomisija.ProgramId;
                komisija.TipKomisijeId = updateKomisija.TipKomisijeId;

                return komisija;
            }

            return null;
        }
    }
}
