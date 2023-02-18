using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;
using Newtonsoft.Json;

namespace Licitacija.Services.ParcelaAPI.ServiceCalls
{
    public class OtvaranjePonudaService :IOtvaranjePonudaService
    {
        private readonly IConfiguration _configuration;

        public OtvaranjePonudaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<OtvaranjePonudaBasicInfoDto> GetOtvaranjePonudaById(Guid otvaranjePonudaId)
        {
            using (HttpClient client = new())
            {
                Uri url = new Uri($"{_configuration["Services:OtvaranjePonudaService"]}api/OtvaranjePonuda/OtvaranjePonudaBasic/" + otvaranjePonudaId);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var otvaranjePonuda = JsonConvert.DeserializeObject<OtvaranjePonudaBasicInfoDto>(responseString);
                        return otvaranjePonuda;
                    }
                }
                return default;
            }
        }
    }
}
