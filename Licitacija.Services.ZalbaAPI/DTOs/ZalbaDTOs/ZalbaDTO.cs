using Licitacija.Services.ZalbaAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.ZalbaAPI.DTOs.RadnjaNaOsnovuZalbeDTOs;
using Licitacija.Services.ZalbaAPI.DTOs.StatusZalbeDTOs;
using Licitacija.Services.ZalbaAPI.DTOs.TipZalbeDTOs;
using System.Text.Json.Serialization;

namespace Licitacija.Services.ZalbaAPI.DTOs.ZalbaDTOs
{
    public class ZalbaDto
    {
        /// <summary>
        /// ID žalbe
        /// </summary>
        public Guid ZalbaId { get; set; }

        /// <summary>
        /// Datum podnosenja
        /// </summary>
        public DateTime DatumPodnosenja { get; set; }

        /// <summary>
        /// Datum resenja
        /// </summary>
        public DateTime DatumResenja { get; set; }

        /// <summary>
        /// Razlog zalbe
        /// </summary>
        public string RazlogZalbe { get; set; }

        /// <summary>
        /// Obrazlozenje
        /// </summary>
        public string Obrazlozenje { get; set; }

        /// <summary>
        /// Broj nadmetanja
        /// </summary>
        public string BrojNadmetanja { get; set; }

        /// <summary>
        /// Broj odluke
        /// </summary>
        public string BrojOdluke { get; set; }

        /// <summary>
        /// Broj resenja
        /// </summary>
        public string BrojResenja { get; set; }

        /// <summary>
        /// Podaci o statusu zalbe.
        /// </summary>
        public StatusZalbeDto? StatusZalbe { get; set; }

        /// <summary>
        /// Podaci o tipu zalbe.
        /// </summary>
        public TipZalbeDto? TipZalbe { get; set; }
        /// <summary>
        /// Podaci o radnji na osnovu zalbe.
        /// </summary>
        public RadnjaNaOsnovuZalbeDto? RadnjaNaOsnovuZalbe { get; set; }

        /// <summary>
        /// Id kupca - veza sa mikroservisom Kupac 
        /// </summary>
        [JsonIgnore]
        public Guid KupacId { get; set; }
        public KupacDto? Kupac { get; set; }

        [JsonIgnore]
        public Guid FazaId { get; set; }
        public FazaLicitacijeDto? FazaLicitacije { get; set; }
    }
}
