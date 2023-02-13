using Licitacija.Services.Gateway.Dtos;

namespace Licitacija.Services.Gateway.Services
{
    public interface IUplataService
    {
        Task<T> GetUplata<T>(string token);
        Task<T> GetUplataById<T>(Guid id, string token);
        Task<T> CreateUplata<T>(UplataCreateDto uplata, string token);
        Task<T> UpdateUplata<T>(UplataUpdateDto uplata, string token);
        Task<T> DeleteUplata<T>(Guid id, string token);
    }
}
