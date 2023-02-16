using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Models;

namespace Licitacija.Services.Gateway.Services.Implementation
{
    public class AdresaService : BaseService, IAdresaService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AdresaService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateAdresa<T>(AdresaCreateDTO adresa, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = adresa,
                Url = SD.AdresaAPIBase + "/api/adresa",
                AccessToken = token
            });
        }

        public async Task<T> DeleteAdresa<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = id,
                Url = SD.AdresaAPIBase + "/api/adresa/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetAdresa<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AdresaAPIBase + "/api/adresa",
                AccessToken = token
            });
        }

        public async Task<T> GetAdresaBezDrzave<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Data = id,
                Url = SD.AdresaAPIBase + "/api/adresa/adresaBezDrzave/" + id,
                AccessToken = token
            });
        }


        public async Task<T> GetAdresaById<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Data = id,
                Url = SD.AdresaAPIBase + "/api/adresa/" + id,
                AccessToken = token
            });
        }


        public async Task<T> UpdateAdresa<T>(AdresaUpdateDTO adresa, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = adresa,
                Url = SD.AdresaAPIBase + "/api/adresa",
                AccessToken = token
            });
        }
    }
}
