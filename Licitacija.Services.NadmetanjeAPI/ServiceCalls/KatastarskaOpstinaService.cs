using Licitacija.Services.NadmetanjeAPI.Models;
using Newtonsoft.Json;

namespace Licitacija.Services.NadmetanjeAPI.ServiceCalls
{
    public class KatastarskaOpstinaService : IKatastarskaOpstinaService
    {
        private readonly IConfiguration _configuration;

        public KatastarskaOpstinaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<KatastarskaOpstinaDto> GetKatastarskaOpstinaById(Guid id)
        {
            using (HttpClient client = new())
            {
                Uri url = new Uri($"{_configuration["Services:KatastarskaOpstinaService"]}api/KatastarskaOpstina/KatastarskaOpstinaBasicInfo/" + id);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var katastarskaOpstina= JsonConvert.DeserializeObject<KatastarskaOpstinaDto>(responseString);
                        return katastarskaOpstina;
                    }
                }
                return default;
            }
        }
    }
    
}
