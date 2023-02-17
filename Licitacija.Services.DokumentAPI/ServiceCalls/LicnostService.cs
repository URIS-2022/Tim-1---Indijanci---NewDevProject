﻿using Licitacija.Services.DokumentAPI.Models.ExchangeDtos;
using Newtonsoft.Json;

namespace Licitacija.Services.DokumentAPI.ServiceCalls
{
    public class LicnostService : ILicnostService
    {
        private readonly IConfiguration _configuration;

        public LicnostService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<LicnostDto?> GetLicnostZaUgovor(Guid? licnostId)
        {
            using HttpClient client = new();
            Uri url = new($"{_configuration["Services:LicnostService"]}api/licnost/licnostZaUgovor/{licnostId}");

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseString))
                {
                    return default;
                }

                LicnostDto? kupac = JsonConvert.DeserializeObject<LicnostDto>(responseString);
                return kupac;
            }
            return default;
        }
    }
}
