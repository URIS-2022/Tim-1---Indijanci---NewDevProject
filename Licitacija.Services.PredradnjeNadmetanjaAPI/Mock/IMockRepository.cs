using Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Mock
{
    public interface IMockRepository
    {
        public FazaDto GetFazaById(Guid fazaId);
    }
}
