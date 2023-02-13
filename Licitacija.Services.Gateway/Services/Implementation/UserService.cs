using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Models;
using Newtonsoft.Json.Linq;

namespace Licitacija.Services.Gateway.Services.Implementation
{
    public class UserService : BaseService, IUserService
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> Login<T>(LoginDTO loginInfo)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = loginInfo,
                Url = SD.IdentityAPIBase + "/api/User/Login"
            });
        }

        public async Task<T> Logout<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.IdentityAPIBase + "/api/User/Logout"
            });
        }

        public async Task<T> Register<T>(RegisterDTO registerInfo)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = registerInfo,
                Url = SD.IdentityAPIBase + "/api/User/Register"
            });
        }
    }
}
