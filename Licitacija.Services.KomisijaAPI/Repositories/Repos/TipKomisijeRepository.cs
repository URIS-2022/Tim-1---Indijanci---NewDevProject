using Licitacija.Services.KomisijaAPI.DbConexts;
using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.TipKomisijeDtos;
using Licitacija.Services.TipKomisijeAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.KomisijaAPI.Repositories.Repos
{
    public class TipKomisijeRepository : ITipKomisijeRepository
    {
        private readonly DataContext _context;

        public TipKomisijeRepository(DataContext context)
        {
            _context = context;
        }

        public TipKomisije AddTipKomisije(AddTipKomisijeDto addTipKomisije)
        {
            var tipKomisije = new TipKomisije()
            {
                TipKomisijeId = Guid.NewGuid(),
                TipKomisijeNaziv = addTipKomisije.TipKomisijeNaziv
            };

            _context.TipKomisije.Add(tipKomisije);

            return tipKomisije;
        }

        public async Task<bool> DeleteTipKomisijeById(Guid id)
        {
            var tipKomisije = await GetTipKomisijeById(id);

            if (tipKomisije == null)
            {
                return false;
            }

            _context.Remove(tipKomisije);

            return true;
        }

        public async Task<List<TipKomisije>> GetAllTipoveKomisije()
        {
            return await _context.TipKomisije.Include(tk => tk.Komisije).ToListAsync();
        }

        public async Task<TipKomisije?> GetTipKomisijeById(Guid id)
        {
            return await _context.TipKomisije.Include(tk => tk.Komisije).Where(tk => tk.TipKomisijeId == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<TipKomisije?> UpdateTipKomisije(UpdateTipKomisijeDto updateTipKomisije)
        {
            TipKomisije? tipKomisije = await _context.TipKomisije.FirstOrDefaultAsync(tk => tk.TipKomisijeId == updateTipKomisije.TipKomisijeId);

            if (tipKomisije != null)
            {
                tipKomisije.TipKomisijeNaziv = updateTipKomisije.TipKomisijeNaziv;
                return tipKomisije;
            }

            return null;
        }
    }
}
