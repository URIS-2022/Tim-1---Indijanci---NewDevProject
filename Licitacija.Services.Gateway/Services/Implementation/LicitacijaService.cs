using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Models;

namespace Licitacija.Services.Gateway.Services.Implementation
{
    public class LicitacijaService : BaseService, ILicitacijaService
    {
        private readonly IHttpClientFactory _clientFactory;

        public LicitacijaService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateLicitacija<T>(LicitacijaCreateDTO licitacija, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = licitacija,
                Url = SD.LicitacijaAPIBase + "/api/Licitacija",
                AccessToken = token
            });
        }

        public async Task<T> DeleteLicitacija<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = id,
                Url = SD.LicitacijaAPIBase + "/api/Licitacija/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetLicitacija<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.LicitacijaAPIBase + "/api/Licitacija",
                AccessToken = token
            });
        }

        public async Task<T> GetLicitacijaById<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Data = id,
                Url = SD.LicitacijaAPIBase + "/api/Licitacija/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateLicitacija<T>(LicitacijaUpdateDTO licitacija, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = licitacija,
                Url = SD.LicitacijaAPIBase + "/api/Licitacija",
                AccessToken = token
            });
        }
    }
}
