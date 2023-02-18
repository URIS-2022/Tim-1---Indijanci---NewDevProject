using System.Text.Json.Serialization;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model javnog nadmetanja.
    /// </summary>
    public class JavnoDto
    {
        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        public Guid JavnoNadmetanjeId { get; set; }

        /// <summary>
        /// Objekat nadmetanja.
        /// </summary>
        public NadmetanjeDto? Nadmetanje { get; set; }

        /// <summary>
        /// ID etape.
        /// </summary>
        [JsonIgnore]
        public Guid EtapaId { get; set; }

        /// <summary>
        /// Objekat etape.
        /// </summary>
        public EtapaDto? Etapa { get; set; }
    }
}
