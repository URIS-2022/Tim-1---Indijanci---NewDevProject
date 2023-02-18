using Licitacija.Services.DokumentAPI.Models.ExchangeDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Licitacija.Services.DokumentAPI.ServiceCalls
{
    public class KupacService : IKupacService
    {

        private readonly IConfiguration _configuration;

        public KupacService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<KupacDto?> GetKupacWithTip(Guid? kupacId)
        {
            using HttpClient client = new();

            Uri url = new($"{_configuration["Services:KupacService"]}api/kupac/kupacSaTipom/{kupacId}");

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

                    KupacDto? kupac = JsonConvert.DeserializeObject<KupacDto>(responseString);
                    return kupac;
                }
                return default;
            }
            catch(Exception)
            {
                return null;
            }
            
        }
    }
}
