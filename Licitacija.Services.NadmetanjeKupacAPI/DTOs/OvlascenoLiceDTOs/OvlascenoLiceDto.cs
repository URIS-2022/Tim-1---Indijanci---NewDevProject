

using Licitacija.Services.NadmetanjeKupacAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.NadmetanjeKupacAPI.Entities;
using System.Text.Json.Serialization;

namespace Licitacija.Services.NadmetanjeKupacAPI.DTOs.OvlascenoLiceDTOs
{
    public class OvlascenoLiceDto
    {
        /// <summary>
        /// ID ovlasceno lice
        /// </summary>
        public Guid OvlascenoLiceId { get; set; }

        /// <summary>
        /// Ime
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Broj pasosa
        /// </summary>
        public string BrojPasosa { get; set; }

        /// <summary>
        /// JMBG
        /// </summary>
        public string JMBG { get; set; }

        /// <summary>
        /// Id adrese - veza sa mikroservisom Adresa 
        /// </summary>
        [JsonIgnore]
        public Guid AdresaId { get; set; }
        public AdresaDto? Adresa { get; set; }
    }
}
