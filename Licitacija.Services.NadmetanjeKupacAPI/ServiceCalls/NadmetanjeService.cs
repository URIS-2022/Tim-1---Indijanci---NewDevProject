using Licitacija.Services.NadmetanjeKupacAPI.DTOs.ExchangeDTOs;
using Newtonsoft.Json;

namespace Licitacija.Services.NadmetanjeKupacAPI.ServiceCalls
{
    public class NadmetanjeService : INadmetanjeService
    {
        private readonly IConfiguration _configuration;

        public NadmetanjeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<NadmetanjeDto> GetNadmetanjeById(Guid nadmetanjeId)
        {
            using (HttpClient client = new())
            {
                Uri url = new Uri($"{_configuration["Services:NadmetanjeService"]}api/Nadmetanje/NadmetanjeBasic/" + nadmetanjeId);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var nadmetanje = JsonConvert.DeserializeObject<NadmetanjeDto>(responseString);
                        return nadmetanje;
                    }
                }
                return default;
            }
        }
    }
}
