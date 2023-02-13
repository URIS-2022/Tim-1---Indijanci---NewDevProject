using Licitacija.Services.KupacAPI.DTOs.ExchangeDTOs;
using Newtonsoft.Json;

namespace Licitacija.Services.KupacAPI.ServiceCalls
{
    public class AdresaService : IAdresaService
    {
        private readonly IConfiguration _configuration;

        public AdresaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AdresaDto> GetAdresaById(Guid adresaId)
        {
            using (HttpClient client = new())
            {
                Uri url = new($"{_configuration["Services:AdresaService"]}api/adresa/adresaBezDrzave/" + adresaId);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }

                    var adresa = JsonConvert.DeserializeObject<AdresaDto>(responseString);
                    return adresa;
                }
                return default;
            }
        }
    }
}
