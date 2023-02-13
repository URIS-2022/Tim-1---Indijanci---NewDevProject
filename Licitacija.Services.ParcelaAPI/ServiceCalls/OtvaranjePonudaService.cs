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

        public async Task<OtvaranjePonudaBasicInfoDTO> GetOtvaranjePonudaById(Guid nadmetanjeId)
        {
            using (HttpClient client = new())
            {
                Uri url = new Uri($"{_configuration["Services:NadmetanjeService"]}api/nadmetanje/nadmetanjeBasicInfo/" + nadmetanjeId);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var nadmetanje = JsonConvert.DeserializeObject<OtvaranjePonudaBasicInfoDTO>(responseString);
                        return nadmetanje;
                    }
                }
                return default;
            }
        }
    }
}
