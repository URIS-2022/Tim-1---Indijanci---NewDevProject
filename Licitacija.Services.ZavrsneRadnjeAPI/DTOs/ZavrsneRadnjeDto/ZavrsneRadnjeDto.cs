using Licitacija.Services.ZavrsneRadnjeAPI.DTOs.ExchangeDto;
using Newtonsoft.Json;

namespace Licitacija.Services.ZavrsneRadnjeAPI.DTOs.ZavrsneRadnjeDto
{
    /// <summary>
    /// DTO zavrsnje radnje.
    /// </summary>
    public class ZavrsneRadnjeDto
    {
        /// <summary>
        /// ID zavsne radnje.
        /// </summary>
        public Guid ZavrsnaRadnjaId { get; set; }

        /// <summary>
        /// Naziv zavrsne radnje.
        /// </summary>
        public string ZavrsnaRadnjaNaziv { get; set; } 

        /// <summary>
        /// Id faze (strani kljuc).
        /// </summary>
        [JsonIgnore]
        public Guid FazaId { get; set; }

        /// <summary>
        /// DTO faze za prikaz podataka o fazi.
        /// </summary>
        public FazaLicitacijeDto? FazaLicitacije { get; set; }
    }
}
