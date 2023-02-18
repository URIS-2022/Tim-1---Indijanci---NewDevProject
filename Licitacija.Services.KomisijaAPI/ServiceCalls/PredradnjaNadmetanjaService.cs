using Licitacija.Services.KomisijaAPI.Models.ExchangeDtos;
using Newtonsoft.Json;

namespace Licitacija.Services.KomisijaAPI.ServiceCalls
{
    public class PredradnjaNadmetanjaService : IPredradnjaNadmetanjaService
    {

        private readonly IConfiguration _configuration;

        public PredradnjaNadmetanjaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PredradnjaNadmetanjaDto?> GetPredradnjaNadmetanja(Guid? predradnjaNadmetanjaId)
        {
            using HttpClient client = new();
            Uri url = new($"{_configuration["Services:PredradnjaNadmetanjaService"]}api/predradnjeNadmetanja/predradnjaOsnovneInfo/{predradnjaNadmetanjaId}");

            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }

                    PredradnjaNadmetanjaDto? predradnjaNadmetanja = JsonConvert.DeserializeObject<PredradnjaNadmetanjaDto>(responseString);
                    return predradnjaNadmetanja;
                }
                return default;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
