using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Models;

namespace Licitacija.Services.Gateway.Services.Implementation
{
    public class DrzavaService : BaseService, IDrzavaService
    {
        private readonly IHttpClientFactory _clientFactory;

        public DrzavaService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateDrzava<T>(DrzavaCreateDTO drzava, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = drzava,
                Url = SD.AdresaAPIBase + "/api/drzava",
                AccessToken = token
            });
        }

        public async Task<T> DeleteDrzava<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = id,
                Url = SD.AdresaAPIBase + "/api/drzava/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetDrzava<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AdresaAPIBase + "/api/drzava",
                AccessToken = token
            });
        }

        public async Task<T> GetDrzavaById<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Data = id,
                Url = SD.AdresaAPIBase + "/api/drzava/" + id,
                AccessToken = token
            });
        }


        public async Task<T> UpdateDrzava<T>(DrzavaUpdateDTO drzava, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = drzava,
                Url = SD.AdresaAPIBase + "/api/drzava",
                AccessToken = token
            });
        }
    }
}
