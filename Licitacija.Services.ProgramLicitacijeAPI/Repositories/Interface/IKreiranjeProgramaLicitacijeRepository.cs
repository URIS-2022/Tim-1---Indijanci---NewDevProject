using Licitacija.Services.ProgramLicitacijeAPI.Entities;
using Licitacija.Services.ProgramLicitacijeAPI.Models.KreiranjeProgramaLicitacijeDtos;

namespace Licitacija.Services.ProgramLicitacijeAPI.Repositories.Interface
{
    public interface IKreiranjeProgramaLicitacijeRepository
    {
        Task<List<KreiranjeProgramaLicitacije>> GetAllProgramiLicitacije();
        Task<KreiranjeProgramaLicitacije?> GetKreiranjeProgramaLicitacijeById(Guid id);
        KreiranjeProgramaLicitacije AddKreiranjeProgramaLicitacije(AddProgramLicitacijeDto addProgramLicitacije);
        Task<KreiranjeProgramaLicitacije?> UpdateKreiranjeProgramaLicitacije(UpdateProgramLicitacijeDto updateProgramLicitacije);
        Task<bool> DeleteKreiranjeProgramaLicitacijeById(Guid id);
        Task<int> Save();
    }
}
