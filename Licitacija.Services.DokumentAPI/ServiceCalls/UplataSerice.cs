using Licitacija.Services.DokumentAPI.Models.ExchangeDtos;
using Newtonsoft.Json;

namespace Licitacija.Services.DokumentAPI.ServiceCalls
{
    public class UplataSerice : IUplataService
    {

        private readonly IConfiguration _configuration;

        public UplataSerice(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UplataDto?> GetUplataZaUgovor(Guid? uplataId)
        {
            using HttpClient client = new();
            Uri url = new($"{_configuration["Services:UplataService"]}api/Uplata/uplataZaUgovor/{uplataId}");

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

                    UplataDto? uplata = JsonConvert.DeserializeObject<UplataDto>(responseString);
                    return uplata;
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
