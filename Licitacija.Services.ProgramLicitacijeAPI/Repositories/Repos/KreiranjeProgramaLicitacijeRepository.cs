using Licitacija.Services.ProgramLicitacijeAPI.DbConexts;
using Licitacija.Services.ProgramLicitacijeAPI.Entities;
using Licitacija.Services.ProgramLicitacijeAPI.Models.KreiranjeProgramaLicitacijeDtos;
using Licitacija.Services.ProgramLicitacijeAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.ProgramLicitacijeAPI.Repositories.Repos
{
    public class KreiranjeProgramaLicitacijeRepository : IKreiranjeProgramaLicitacijeRepository
    {

        private readonly DataContext _context;

        public KreiranjeProgramaLicitacijeRepository(DataContext context)
        {
            _context = context;
        }
        public KreiranjeProgramaLicitacije AddKreiranjeProgramaLicitacije(AddProgramLicitacijeDto addProgramLicitacije)
        {
            var program = new KreiranjeProgramaLicitacije()
            {
                ProgramId = Guid.NewGuid(),
                ProgramNaziv = addProgramLicitacije.ProgramNaziv,
                FazaLicitacijeId = addProgramLicitacije.FazaLicitacijeId,
            };

            _context.KreiranjeProgramaLicitacije.Add(program);

            return program;
        }

        public async Task<bool> DeleteKreiranjeProgramaLicitacijeById(Guid id)
        {
            var program = await GetKreiranjeProgramaLicitacijeById(id);

            if (program == null)
            {
                return false;
            }

            _context.Remove(program);

            return true;
        }

        public async Task<List<KreiranjeProgramaLicitacije>> GetAllProgramiLicitacije()
        {
            return await _context.KreiranjeProgramaLicitacije.ToListAsync();
        }

        public async Task<KreiranjeProgramaLicitacije?> GetKreiranjeProgramaLicitacijeById(Guid id)
        {
           return await _context.KreiranjeProgramaLicitacije.Where(kpl => kpl.ProgramId == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<KreiranjeProgramaLicitacije?> UpdateKreiranjeProgramaLicitacije(UpdateProgramLicitacijeDto updateProgramLicitacije)
        {
            KreiranjeProgramaLicitacije? program = await _context.KreiranjeProgramaLicitacije.FirstOrDefaultAsync(kpl => kpl.ProgramId== updateProgramLicitacije.ProgramId);

            if (program != null)
            {
                program.ProgramNaziv = updateProgramLicitacije.ProgramNaziv;
                program.FazaLicitacijeId = updateProgramLicitacije.FazaLicitacijeId;

                return program;
            }

            return null;
        }
    }
}
