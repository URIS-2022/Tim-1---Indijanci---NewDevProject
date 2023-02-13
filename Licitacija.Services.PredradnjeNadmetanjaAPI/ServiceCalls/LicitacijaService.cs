using Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs;
using Newtonsoft.Json;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.ServiceCalls
{
    public class LicitacijaService : ILicitacijaService
    {
        private readonly IConfiguration _configuration;

        public LicitacijaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<FazaDto> GetFazaById(Guid fazaid)
        {
            using (HttpClient client = new())
            {
                Uri url = new($"{_configuration["Services:LicitacijaService"]}api/FazaLicitacije/FazaLicitacijeBasic/" + fazaid);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }

                    var faza = JsonConvert.DeserializeObject<FazaDto>(responseString);
                    return faza;
                }
                return default;
            }
        }
    }
}
