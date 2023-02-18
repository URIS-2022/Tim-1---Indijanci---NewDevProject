using Licitacija.Services.DokumentAPI.DbConexts;
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.UgovorOZakupuDtos;
using Licitacija.Services.DokumentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.DokumentAPI.Repositories.Repos
{
    public class UgovorOZakupuRepository : IUgovorOZakupuRepository
    {
        private readonly DataContext _context;

        public UgovorOZakupuRepository(DataContext context)
        {
            _context = context;
        }

        public UgovorOZakupu AddUgovorOZakupu(AddUgovorOZakupuDto addUgovorOZakupu)
        {
            var ugovorOZakupu = new UgovorOZakupu()
            {
                UgovorOZakupuId = Guid.NewGuid(),
                DokumentId = addUgovorOZakupu.DokumentId,
                LicnostId = addUgovorOZakupu.LicnostId,
                MestoPotpisivanja = addUgovorOZakupu.MestoPotpisivanja,
                RokDospeca = addUgovorOZakupu.RokDospeca,
                RokVracanjaZemljista = addUgovorOZakupu.RokVracanjaZemljista,
                TipGarancijeId = addUgovorOZakupu.TipGarancijeId,
                UplataId = addUgovorOZakupu.UplataId,
            };

            _context.UgovorOZakupu.Add(ugovorOZakupu);

            return ugovorOZakupu;
        }

        public async Task<bool> DeleteUgovorOZakupuById(Guid id)
        {
            var ugovorOZakupu = await GetUgovorOZakupuById(id);

            if (ugovorOZakupu == null)
            {
                return false;
            }

            _context.Remove(ugovorOZakupu);

            return true;
        }

        public async Task<List<UgovorOZakupu>> GetAllUgovorOZakupu()
        {
            return await _context.UgovorOZakupu.Include(uz => uz.Dokument)
                .Include(uz => uz.TipGarancije).ToListAsync();
        }

        public async Task<UgovorOZakupu?> GetUgovorOZakupuById(Guid id)
        {
            return await _context.UgovorOZakupu.Include(uz => uz.Dokument)
                .Include(uz => uz.TipGarancije).Where(uz => uz.UgovorOZakupuId == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<UgovorOZakupu?> UpdateUgovorOZakupu(UpdateUgovorOZakupuDto updateUgovorOZakupu)
        {
            UgovorOZakupu? ugovorOZakupu = await _context.UgovorOZakupu.FirstOrDefaultAsync(uz => uz.UgovorOZakupuId == updateUgovorOZakupu.UgovorOZakupuId);

            if (ugovorOZakupu != null)
            {
                ugovorOZakupu.RokVracanjaZemljista = updateUgovorOZakupu.RokVracanjaZemljista;
                ugovorOZakupu.TipGarancijeId = updateUgovorOZakupu.TipGarancijeId;
                ugovorOZakupu.MestoPotpisivanja = updateUgovorOZakupu.MestoPotpisivanja;
                ugovorOZakupu.DokumentId = updateUgovorOZakupu.DokumentId;
                ugovorOZakupu.LicnostId = updateUgovorOZakupu.LicnostId;
                ugovorOZakupu.UplataId = updateUgovorOZakupu.UplataId;

                return ugovorOZakupu;
            }

            return null;
        }
    }
}
