using Licitacija.Services.NadmetanjeAPI.Models;
using Newtonsoft.Json;

namespace Licitacija.Services.NadmetanjeAPI.ServiceCalls
{
    public class AdresaService : IAdresaService
    {
        private readonly IConfiguration _configuration;

        public AdresaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async  Task<AdresaDto> GetAdresaById(Guid id)
        {
            using (HttpClient client = new())
            {
                Uri url = new Uri($"{_configuration["Services:AdresaService"]}api/adresa/adresaBezDrzave/" + id);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var adresa = JsonConvert.DeserializeObject<AdresaDto>(responseString);
                        return adresa;
                    }
                }
                return default;
            }
        }
    }
}
