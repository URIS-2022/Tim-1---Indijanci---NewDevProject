using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;
using Newtonsoft.Json;

namespace Licitacija.Services.ParcelaAPI.ServiceCalls
{
    public class EtapaService : IEtapaService
    {
        private readonly IConfiguration _configuration;

        public EtapaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<EtapaBasicInfoDto> GetEtapaById(Guid etapaId)
        {
            using (HttpClient client = new())
            {
                Uri url = new Uri($"{_configuration["Services:EtapaService"]}api/Etapa/EtapaBasicInfo/" + etapaId);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var etapa = JsonConvert.DeserializeObject<EtapaBasicInfoDto>(responseString);
                        return etapa;
                    }
                }
                return default;
            }
        }
    }
}
