using Licitacija.Services.Gateway.Dtos;

namespace Licitacija.Services.Gateway.Services
{
    public interface ILicitacijaService
    {
        Task<T> GetLicitacija<T>(string token);
        Task<T> GetLicitacijaById<T>(Guid id, string token);
        Task<T> CreateLicitacija<T>(LicitacijaCreateDTO licitacija, string token);
        Task<T> UpdateLicitacija<T>(LicitacijaUpdateDTO licitacija, string token);
        Task<T> DeleteLicitacija<T>(Guid id, string token);
    }
}
