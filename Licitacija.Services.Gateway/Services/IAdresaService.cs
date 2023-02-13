using Licitacija.Services.Gateway.Dtos;

namespace Licitacija.Services.Gateway.Services
{
    public interface IAdresaService
    {
        Task<T> GetAdresa<T>(string token);
        Task<T> GetAdresaById<T>(Guid id, string token);
        Task<T> CreateAdresa<T>(AdresaCreateDTO adresa, string token);
        Task<T> UpdateAdresa<T>(AdresaUpdateDTO adresa, string token);
        Task<T> DeleteAdresa<T>(Guid id, string token);
        Task<T> GetAdresaBezDrzave<T>(Guid id, string token);
    }
}
