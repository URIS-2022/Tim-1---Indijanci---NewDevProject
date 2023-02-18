using Licitacija.Services.DokumentAPI.DbConexts;
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.TipGarancijeDtos;
using Licitacija.Services.DokumentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.DokumentAPI.Repositories.Repos
{
    public class TipGarancijeRepository : ITipGarancijeRepository
    {
        private readonly DataContext _context;

        public TipGarancijeRepository(DataContext context)
        {
            _context = context;
        }

        public TipGarancije AddTipGarancije(AddTipGarancijeDto addTipGarancije)
        {
            var tipGarancije = new TipGarancije()
            {
                TipGarancijeId = Guid.NewGuid(),
                TipGarancijeNaziv = addTipGarancije.TipGarancijeNaziv
            };

            _context.TipGarancije.Add(tipGarancije);

            return tipGarancije;
        }

        public async Task<bool> DeleteTipGarancijeById(Guid id)
        {
            var tipGarancije = await GetTipGarancijeById(id);

            if (tipGarancije == null)
            {
                return false;
            }

            _context.Remove(tipGarancije);

            return true;
        }

        public async Task<List<TipGarancije>> GetAllTipGarancije()
        {
            return await _context.TipGarancije.Include(tg => tg.UgovoriOZakupu).ToListAsync();
        }

        public async Task<TipGarancije?> GetTipGarancijeById(Guid id)
        {
            return await _context.TipGarancije.Include(tg => tg.UgovoriOZakupu).Where(tg => tg.TipGarancijeId == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<TipGarancije?> UpdateTipGarancije(UpdateTipGarancijeDto updateTipGarancije)
        {
            TipGarancije? tipGarancije = await _context.TipGarancije.FirstOrDefaultAsync(tg => tg.TipGarancijeId == updateTipGarancije.TipGarancijeId);

            if (tipGarancije != null)
            {
                tipGarancije.TipGarancijeNaziv = updateTipGarancije.TipGarancijeNaziv;
                
                return tipGarancije;
            }

            return null;
        }
    }
}
