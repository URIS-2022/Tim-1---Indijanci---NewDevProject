using Licitacija.Services.KomisijaAPI.DbConexts;
using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.LicnostKomisijaDtos;
using Licitacija.Services.KomisijaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.KomisijaAPI.Repositories.Repos
{
    public class LicnostKomisijaRepository : ILicnostKomisijaRepository
    {

        private readonly DataContext _context;

        public LicnostKomisijaRepository(DataContext context)
        {
            _context = context;
        }

        public LicnostKomisija? AddLicnostKomisija(AddLicnostKomisijaDto addLicnostKomisija, Guid LicnostId)
        {

            if (_context.Licnost.Any(l => l.LicnostId == LicnostId) && _context.Komisija.Any(k => k.KomisijaId == addLicnostKomisija.KomisijaId))
            {

                LicnostKomisija licnostKomisija = new LicnostKomisija()
                {
                    LicnostId = LicnostId,
                    KomisijaId = addLicnostKomisija.KomisijaId
                };

                _context.LicnostKomisija.Add(licnostKomisija);

                return licnostKomisija;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<bool> DeleteLicnostKomisijaById(Guid licnostId, Guid komisijaId)
        {
            var licnostKomisija = await GetLicnostKomisijaById(licnostId, komisijaId);

            if (licnostKomisija == null)
            {
                return false;
            }

            _context.Remove(licnostKomisija);

            return true;
        }

        public async Task<List<LicnostKomisija>> GetAllLicnostKomisija()
        {
            return await _context.LicnostKomisija.Include(lk => lk.Licnost).Include(lk => lk.Komisija).ToListAsync();
        }

        public async Task<LicnostKomisija?> GetLicnostKomisijaById(Guid licnostId, Guid komisijaId)
        {
            return await _context.LicnostKomisija.Include(lk => lk.Licnost).Include(lk => lk.Komisija).Where(lk => lk.LicnostId == licnostId && lk.KomisijaId == komisijaId).FirstOrDefaultAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<LicnostKomisija?> UpdateLicnostKomisija(LicnostKomisija updateLicnostKomisija, Guid komisijaId)
        {
            await DeleteLicnostKomisijaById(updateLicnostKomisija.LicnostId, komisijaId);

            await Save();

            LicnostKomisija licnostKomisija = new LicnostKomisija()
            {
                LicnostId = updateLicnostKomisija.LicnostId,
                KomisijaId = updateLicnostKomisija.KomisijaId
            };

            return licnostKomisija;
        }
    }
}
