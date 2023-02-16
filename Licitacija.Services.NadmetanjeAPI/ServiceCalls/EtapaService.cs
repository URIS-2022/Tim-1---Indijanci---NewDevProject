using Licitacija.Services.NadmetanjeAPI.Models;
using Newtonsoft.Json;

namespace Licitacija.Services.NadmetanjeAPI.ServiceCalls
{
    public class EtapaService : IEtapaService
    {
        private readonly IConfiguration _configuration;

        public EtapaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<EtapaDto> GetEtapaById(Guid id)
        {
            using (HttpClient client = new())
            {
                Uri url = new Uri($"{_configuration["Services:EtapaService"]}api/Etapa/EtapaBasicInfo/" + id);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var etapa = JsonConvert.DeserializeObject<EtapaDto>(responseString);
                        return etapa;
                    }
                }
                return default;
            }
        }
    }
}
