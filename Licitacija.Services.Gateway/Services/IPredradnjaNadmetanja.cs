using Licitacija.Services.Gateway.Dtos;

namespace Licitacija.Services.Gateway.Services
{
    public interface IPredradnjaNadmetanja
    {
        Task<T> GetPredradnjaNadmetanja<T>(string token);
        Task<T> GetPredradnjaNadmetanjaById<T>(Guid id, string token);
        Task<T> CreatePredradnjaNadmetanja<T>(PredradnjeNadmetanjaCreateDto predradnjaNadmetanja, string token);
        Task<T> UpdatePredradnjaNadmetanja<T>(PredradnjeNadmetanjaUpdateDto predradnjaNadmetanja, string token);
        Task<T> DeletePredradnjaNadmetanja<T>(Guid id, string token);
        Task<T> GetPredradnjaNadmetanjaOsnovneInformacije<T>(Guid id, string token);
    }
}
