using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Models;

namespace Licitacija.Services.Gateway.Services.Implementation
{
    public class KursService : BaseService, IKursService
    {
        private readonly IHttpClientFactory _clientFactory;

        public KursService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateKurs<T>(KursCreateDto kurs, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = kurs,
                Url = SD.UplataAPIBase + "/api/Kurs",
                AccessToken = token
            });
        }

        public async Task<T> DeleteKurs<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = id,
                Url = SD.UplataAPIBase + "/api/Kurs/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetKurs<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UplataAPIBase + "/api/Kurs",
                AccessToken = token
            });
        }

        public async Task<T> GetKursById<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Data = id,
                Url = SD.UplataAPIBase + "/api/Kurs/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateKurs<T>(KursUpdateDto kurs, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = kurs,
                Url = SD.UplataAPIBase + "/api/Kurs",
                AccessToken = token
            });
        }
    }
}
