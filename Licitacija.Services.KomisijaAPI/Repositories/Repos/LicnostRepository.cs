using Licitacija.Services.KomisijaAPI.DbConexts;
using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.LicnostDtos;
using Licitacija.Services.KomisijaAPI.Repositories.Interfaces;
using Licitacija.Services.LicnostAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.KomisijaAPI.Repositories.Repos
{
    public class LicnostRepository : ILicnostRepository
    {
        private readonly DataContext _context;

        public LicnostRepository(DataContext context)
        {
            _context = context;
        }

        public Licnost AddLicnost(AddLicnostDto addLicnost)
        {
            var licnost = new Licnost()
            {
                LicnostId = Guid.NewGuid(),
                Ime = addLicnost.Ime,
                Prezime = addLicnost.Prezime,
                Funkcija = addLicnost.Funkcija
            };

            _context.Licnost.Add(licnost);

            return licnost;
        }

        public async Task<bool> DeleteLicnostById(Guid id)
        {
            var licnost = await GetLicnostById(id);

            if (licnost == null)
            {
                return false;
            }

            _context.Remove(licnost);

            return true;
        }

        public async Task<List<Licnost>> GetAllLicnosti()
        {
            return await _context.Licnost.ToListAsync();
        }

        public async Task<Licnost?> GetLicnostById(Guid id)
        {
            return await _context.Licnost.Where(l => l.LicnostId == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Licnost?> UpdateLicnost(UpdateLicnostDto updateLicnost)
        {
            Licnost? licnost = await _context.Licnost.FirstOrDefaultAsync(l => l.LicnostId == updateLicnost.LicnostId);

            if (licnost != null)
            {
                licnost.Ime = updateLicnost.Ime;
                licnost.Prezime = updateLicnost.Prezime;
                licnost.Funkcija = updateLicnost.Funkcija;

                return licnost;
            }

            return null;
        }
    }
}
