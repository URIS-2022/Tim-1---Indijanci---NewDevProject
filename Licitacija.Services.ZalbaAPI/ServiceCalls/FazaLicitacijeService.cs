﻿using Licitacija.Services.ZalbaAPI.DTOs.ExchangeDTOs;
using Newtonsoft.Json;

namespace Licitacija.Services.ZalbaAPI.ServiceCalls
{
    public class FazaLicitacijeService : IFazaLicitacijeService
    {
        private readonly IConfiguration _configuration;

        public FazaLicitacijeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<FazaLicitacijeDTO> GetFazaLicitacijeById(Guid fazaId)
        {
            using (HttpClient client = new())
            {
                Uri url = new Uri($"{_configuration["Services:KupacService"]}api/fazalicitacije" + fazaId);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var fazaLicitacije = JsonConvert.DeserializeObject<FazaLicitacijeDTO>(responseString);
                        return fazaLicitacije != null ? fazaLicitacije : default;
                    }
                }
                return default;
            }
        }
    }
}
