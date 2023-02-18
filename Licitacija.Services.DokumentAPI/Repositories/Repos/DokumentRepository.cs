using Licitacija.Services.DokumentAPI.DbConexts;
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.DokumentDtos;
using Licitacija.Services.DokumentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.DokumentAPI.Repositories.Repos
{
    public class DokumentRepository : IDokumentRepository
    {
        private readonly DataContext _context;

        public DokumentRepository(DataContext context)
        {
            _context = context;
        }
        public Dokument AddDokument(AddDokumentDto addDokument)
        {
            var dokument = new Dokument()
            {
                DokumentId = Guid.NewGuid(),
                DatumDonosenja = addDokument.DatumDonosenja,
                DatumPotpisivanja = addDokument.DatumPotpisivanja,
                Sablon = addDokument.Sablon,
                ZavodniBroj = addDokument.ZavodniBroj,
                StatusDokumentaId = addDokument.StatusDokumentaId 
            };

            _context.Dokument.Add(dokument);

            return dokument;
        }

        public async Task<bool> DeleteDokumentById(Guid id)
        {
            var dokument = await GetDokumentById(id);

            if (dokument == null)
            {
                return false;
            }

            _context.Remove(dokument);

            return true;
        }

        public async Task<List<Dokument>> GetAllDokumente()
        {
            return await _context.Dokument.Include(d => d.UgovorOZakupu)
                .Include(d => d.StatusDokumenta)
                .Include(d => d.EksterniDokument).ToListAsync();

        }

        public async Task<Dokument?> GetDokumentById(Guid id)
        {
            return await _context.Dokument.Include(d => d.UgovorOZakupu)
                .Include(d => d.StatusDokumenta)
                .Include(d => d.EksterniDokument).Where(s => s.DokumentId == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Dokument?> UpdateDokument(UpdateDokumentDto updateDokument)
        {
            Dokument? dokument = await _context.Dokument.FirstOrDefaultAsync(d => d.DokumentId == updateDokument.DokumentId);

            if (dokument != null)
            {
                dokument.DatumDonosenja = updateDokument.DatumDonosenja;
                dokument.DatumPotpisivanja = updateDokument.DatumPotpisivanja;
                dokument.Sablon = updateDokument.Sablon;
                dokument.ZavodniBroj = updateDokument.ZavodniBroj;
                dokument.StatusDokumentaId = updateDokument.StatusDokumentaId;
                return dokument;
            }

            return null;
        }
    }
}
