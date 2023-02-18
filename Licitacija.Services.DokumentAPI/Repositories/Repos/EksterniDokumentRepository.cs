using Licitacija.Services.DokumentAPI.DbConexts;
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.EksterniDokumentDtos;
using Licitacija.Services.DokumentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.DokumentAPI.Repositories.Repos
{
    public class EksterniDokumentRepository : IEksterniDokumentRepository
    {
        private readonly DataContext _context;

        public EksterniDokumentRepository(DataContext context)
        {
            _context = context;
        }

        public EksterniDokument AddEksterniDokument(AddEksterniDokumentDto addEksterniDokument)
        {
            var eksterniDokument = new EksterniDokument()
            {
                EksterniDokumentId = Guid.NewGuid(),
                DokumentId = addEksterniDokument.DokumentId,
                Ustanova = addEksterniDokument.Ustanova
            };

            _context.EksterniDokument.Add(eksterniDokument);

            return eksterniDokument;
        }

        public async Task<bool> DeleteEksterniDokumentById(Guid id)
        {
            var eksterniDokument = await GetEksterniDokumentById(id);

            if (eksterniDokument == null)
            {
                return false;
            }

            _context.Remove(eksterniDokument);

            return true;
        }

        public async Task<List<EksterniDokument>> GetAllEksterneDokumente()
        {
            return await _context.EksterniDokument.Include(ed => ed.Dokument).ToListAsync();
        }

        public async Task<EksterniDokument?> GetEksterniDokumentById(Guid id)
        {
            return await _context.EksterniDokument.Include(ed => ed.Dokument).Where(ed => ed.EksterniDokumentId == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<EksterniDokument?> UpdateEksterniDokument(UpdateEksterniDokumentDto updateEksterniDokument)
        {
            EksterniDokument? eksterniDokument = await _context.EksterniDokument.FirstOrDefaultAsync(s => s.EksterniDokumentId == updateEksterniDokument.EksterniDokumentId);

            if (eksterniDokument != null)
            {
                eksterniDokument.DokumentId = updateEksterniDokument.DokumentId;
                eksterniDokument.Ustanova = updateEksterniDokument.Ustanova;
                return eksterniDokument;
            }

            return null;
        }
    }
}
