using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Licitacija.Services.NadmetanjeAPI.Entities
{
    public class Javno
    {
        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        [Key]
        public Guid JavnoNadmetanjeId { get; set; }

        /// <summary>
        /// ID nadmetanja.
        /// </summary>
        [ForeignKey("NadmetanjeId")]
        public Guid NadmetanjeId { get; set; }

        /// <summary>
        /// ID etape.
        /// </summary>
        [ForeignKey("EtapaId")]
        public Guid EtapaId { get; set; }

        /// <summary>
        /// Objekat nadmetanja.
        /// </summary>
        [JsonIgnore]
        public Nadmetanje? Nadmetanje { get; set; }


    }
}
