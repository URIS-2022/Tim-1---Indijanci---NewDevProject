using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Dokument.API.Entities
{
    public class EksterniDokument
    {
        /// <summary>
        /// ID Eksternog dokumenta.
        /// </summary>
        [Key]
        public Guid EksterniDokumentId { get; set; }

        /// <summary>
        /// Ustanova kojoj pripada eksterni dokument.
        /// </summary>
        [Required]
        public string Ustanova { get; set; } = String.Empty;

        /// <summary>
        /// Dokument koji predstavlja eksterni dokument.
        /// </summary>
        [JsonIgnore]
        public Dokument? Dokument { get; set; }


    }
}
