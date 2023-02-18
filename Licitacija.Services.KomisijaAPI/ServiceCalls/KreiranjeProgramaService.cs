using Licitacija.Services.KomisijaAPI.Models.ExchangeDtos;
using Newtonsoft.Json;

namespace Licitacija.Services.KomisijaAPI.ServiceCalls
{
    public class KreiranjeProgramaService : IKreiranjeProgramaService
    {

        private readonly IConfiguration _configuration;

        public KreiranjeProgramaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ProgramDto?> GetProgram(Guid? programId)
        {
            using HttpClient client = new();
            Uri url = new($"{_configuration["Services:KreiranjeProgramaService"]}api/kreiranjeProgramaLicitacije/programZaKomisiju/{programId}");

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

                    ProgramDto? program = JsonConvert.DeserializeObject<ProgramDto>(responseString);
                    return program;
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
