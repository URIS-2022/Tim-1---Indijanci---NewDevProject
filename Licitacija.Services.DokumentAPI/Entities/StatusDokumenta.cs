using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.DokumentAPI.Entities
{
    public class StatusDokumenta
    {
        /// <summary>
        /// ID Statusa dokumenta.
        /// </summary>
        [Key]
        public Guid StatusDokumentaId { get; set; }

        /// <summary>
        /// Naziv statusa dokumenta.
        /// </summary>
        [Required]
        public string StatusDokumentaNaziv { get; set; } = string.Empty;

        /// <summary>
        /// Svi dokumenti datog tipa.
        /// </summary>
        public List<Dokument>? Dokumenti { get; set; }
    }
}
