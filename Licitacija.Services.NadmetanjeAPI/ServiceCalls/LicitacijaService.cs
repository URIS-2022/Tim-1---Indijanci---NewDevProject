using Licitacija.Services.NadmetanjeAPI.Models;
using Newtonsoft.Json;

namespace Licitacija.Services.NadmetanjeAPI.ServiceCalls
{
    public class LicitacijaService : ILicitacijaService
    {

        private readonly IConfiguration _configuration;
        public LicitacijaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<LicitacijaDto> GetLicitacijaById(Guid id)
        {
            using (HttpClient client = new())
            {
                Uri url = new Uri($"{_configuration["Services:LicitacijaService"]}api/Licitacija/LicitacijaBasic/" + id);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var licitacija = JsonConvert.DeserializeObject<LicitacijaDto>(responseString);
                        return licitacija;
                    }
                }
                return default;
            }
        }
    }
}
