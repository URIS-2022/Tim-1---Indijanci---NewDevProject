using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Models;

namespace Licitacija.Services.Gateway.Services.Implementation
{
    public class UplataService : BaseService, IUplataService
    {
        private readonly IHttpClientFactory _clientFactory;

        public UplataService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateUplata<T>(UplataCreateDto uplata, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = uplata,
                Url = SD.UplataAPIBase + "/api/Uplata",
                AccessToken = token
            });
        }

        public async Task<T> DeleteUplata<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = id,
                Url = SD.UplataAPIBase + "/api/Uplata/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetUplata<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UplataAPIBase + "/api/Uplata",
                AccessToken = token
            });
        }

        public async Task<T> GetUplataById<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Data = id,
                Url = SD.UplataAPIBase + "/api/Uplata/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateUplata<T>(UplataUpdateDto uplata, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = uplata,
                Url = SD.UplataAPIBase + "/api/Uplata",
                AccessToken = token
            });
        }
    }
}
