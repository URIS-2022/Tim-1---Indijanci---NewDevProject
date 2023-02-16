using Licitacija.Services.DokumentAPI.DbConexts;
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.StatusDokumentaDtos;
using Licitacija.Services.DokumentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.DokumentAPI.Repositories.Repos
{
    public class StatusDokumentaRepository : IStatusDokumentaRepository
    {
        private readonly DataContext _context;

        public StatusDokumentaRepository(DataContext context)
        {
            _context = context;
        }
        public StatusDokumenta AddStatusDokumenta(AddStatusDokumentaDto statusDokumenta)
        {
            var status = new StatusDokumenta()
            {
                StatusDokumentaId = Guid.NewGuid(),
                StatusDokumentaNaziv = statusDokumenta.StatusDokumentaNaziv
            };

            _context.StatusDokumenta.Add(status);

            return status;
        }

        public async Task<List<StatusDokumenta>> GetAllStatusDokumenta()
        {
            return await _context.StatusDokumenta.Include(s => s.Dokumenti).ToListAsync();
        }

        public async Task<StatusDokumenta?> GetStatusDokumentaById(Guid id)
        {
            return await _context.StatusDokumenta.Include(s => s.Dokumenti).Where(s => s.StatusDokumentaId == id).FirstOrDefaultAsync();
        }

        public async Task<StatusDokumenta?> UpdateStatusDokumenta(UpdateStatusDokumentaDto statusDokumenta)
        {
            StatusDokumenta? status = await _context.StatusDokumenta.FirstOrDefaultAsync(s => s.StatusDokumentaId == statusDokumenta.StatusDokumentaId);

            if(status != null)
            {
                status.StatusDokumentaNaziv = statusDokumenta.StatusDokumentaNaziv;
                return status;
            }

            return null;
        }

        public async Task<bool> DeleteStatusDokumentaById(Guid id)
        {
            var status = await GetStatusDokumentaById(id);

            if(status == null)
            {
                return false;
            }

            _context.Remove(status);

            return true;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
