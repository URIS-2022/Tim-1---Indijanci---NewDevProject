using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Models;

namespace Licitacija.Services.Gateway.Services.Implementation
{
    public class PredradnjaNadmetanjaService : BaseService, IPredradnjaNadmetanja
    {
        private readonly IHttpClientFactory _clientFactory;

        public PredradnjaNadmetanjaService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreatePredradnjaNadmetanja<T>(PredradnjeNadmetanjaCreateDto predradnjaNadmetanja, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = predradnjaNadmetanja,
                Url = SD.PredradnjeNadmetanjaAPIBase + "/api/predradnjeNadmetanja",
                AccessToken = token
            });
        }

        public async Task<T> DeletePredradnjaNadmetanja<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = id,
                Url = SD.PredradnjeNadmetanjaAPIBase + "/api/predradnjeNadmetanja/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetPredradnjaNadmetanja<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.PredradnjeNadmetanjaAPIBase + "/api/predradnjeNadmetanja",
                AccessToken = token
            });
        }

        public async Task<T> GetPredradnjaNadmetanjaById<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Data = id,
                Url = SD.PredradnjeNadmetanjaAPIBase + "/api/predradnjeNadmetanja/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetPredradnjaNadmetanjaOsnovneInformacije<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Data = id,
                Url = SD.PredradnjeNadmetanjaAPIBase + "/api/predradnjeNadmetanja/predradnjaOsnovneInfo/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdatePredradnjaNadmetanja<T>(PredradnjeNadmetanjaUpdateDto predradnjaNadmetanja, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = predradnjaNadmetanja,
                Url = SD.PredradnjeNadmetanjaAPIBase + "/api/predradnjeNadmetanja",
                AccessToken = token
            });
        }
    }
}
