using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Dokument.API.Entities
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
        public string StatusDokumentaNaziv { get; set; } = String.Empty;
    }
}
