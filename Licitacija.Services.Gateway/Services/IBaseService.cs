using Licitacija.Services.Gateway.Models;

namespace Licitacija.Services.Gateway.Services
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
