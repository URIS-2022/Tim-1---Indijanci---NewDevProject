using Licitacija.Services.NadmetanjeKupacAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Licitacija.Services.NadmetanjeKupacAPI.DTOs.OvlascenoLiceDTOs;
using Licitacija.Services.NadmetanjeKupacAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.NadmetanjeKupacAPI.DTOs.NadmetanjeKupacDTOs
{
    public class NadmetanjeKupacDto
    {
        /// <summary>
        /// ID nadmetanjeKupac
        /// </summary>
        public Guid NadmetanjeKupacId { get; set; }

        /// <summary>
        /// Objekat ovlasceno lice
        /// </summary>
        public OvlascenoLice? OvlascenoLice { get; set; }

        /// <summary>
        /// Id kupca - veza sa mikroservisom Kupac 
        /// </summary>
        [JsonIgnore]
        public Guid KupacId { get; set; }
        public KupacDto? Kupac { get; set; }
        /// <summary>
        /// Id nadmeranja - veza sa mikroservisom Nadmetanje 
        /// </summary>
        [JsonIgnore]
        public Guid NadmetanjeId { get; set; }
        public NadmetanjeDto? Nadmetanje { get; set; }
    }
}
