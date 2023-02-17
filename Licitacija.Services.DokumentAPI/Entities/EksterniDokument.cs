using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.DokumentAPI.Entities
{
    public class EksterniDokument
    {
        /// <summary>
        /// ID Eksternog dokumenta.
        /// </summary>
        [Key]
        public Guid EksterniDokumentId { get; set; }

        /// <summary>
        /// ID Dokumenta (strani kljuc).
        /// </summary>
        [Required]
        [ForeignKey(nameof(Dokument))]
        public Guid DokumentId { get; set; }

        /// <summary>
        /// Ustanova kojoj pripada eksterni dokument.
        /// </summary>
        [Required]
        public string Ustanova { get; set; } = string.Empty;

        /// <summary>
        /// Dokument koji predstavlja eksterni dokument.
        /// </summary>
        public Dokument? Dokument { get; set; }


    }
}
