using Licitacija.Services.UplataAPI.Models;
using Newtonsoft.Json;

namespace Licitacija.Services.UplataAPI.ServiceCalls
{
    public class KupacService : IKupacService
    {
        private readonly IConfiguration _configuration;

        public KupacService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<KupacDto> GetKupacById(Guid kupacId)
        {
            using(HttpClient client = new())
            {
                Uri url = new Uri($"{_configuration["Services:KupacService"]}api/kupac/kupacOsnovneInfo/" + kupacId);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var kupac = JsonConvert.DeserializeObject<KupacDto>(responseString);
                        return kupac;
                    }
                }
                return default;
            }
        }
    }
}
