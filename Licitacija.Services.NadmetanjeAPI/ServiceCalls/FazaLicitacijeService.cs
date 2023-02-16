using Licitacija.Services.NadmetanjeAPI.Models;
using Newtonsoft.Json;

namespace Licitacija.Services.NadmetanjeAPI.ServiceCalls
{
    public class FazaLicitacijeService : IFazaLicitacijeService
    {
        private readonly IConfiguration _configuration;

        public FazaLicitacijeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<FazaDto> GetFazaLicitacijeById(Guid id)
        {
            using (HttpClient client = new())
            {
                Uri url = new Uri($"{_configuration["Services:FazaLicitacijeService"]}api/FazaLicitacije/FazaLicitacijeBasic/" + id);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var faza = JsonConvert.DeserializeObject<FazaDto>(responseString);
                        return faza;
                    }
                }
                return default;
            }
        }
    }
}
