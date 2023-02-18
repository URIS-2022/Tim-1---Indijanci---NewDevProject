using Licitacija.Services.Gateway.Dtos;

namespace Licitacija.Services.Gateway.Services
{
    public interface IDrzavaService
    {
        Task<T> GetDrzava<T>(string token);
        Task<T> GetDrzavaById<T>(Guid id, string token);
        Task<T> CreateDrzava<T>(DrzavaCreateDTO adresa, string token);
        Task<T> UpdateDrzava<T>(DrzavaUpdateDTO adresa, string token);
        Task<T> DeleteDrzava<T>(Guid id, string token);
    }
}
