using Licitacija.Services.Gateway.Dtos;

namespace Licitacija.Services.Gateway.Services
{
    public interface IKursService
    {
        Task<T> GetKurs<T>(string token);
        Task<T> GetKursById<T>(Guid id, string token);
        Task<T> CreateKurs<T>(KursCreateDto kurs, string token);
        Task<T> UpdateKurs<T>(KursUpdateDto kurs, string token);
        Task<T> DeleteKurs<T>(Guid id, string token);
    }
}
