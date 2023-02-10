using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.UplataAPI.Entities
{
    public class Kurs
    {
        /// <summary>
        /// ID kursa.
        /// </summary>
        [Key]
        public Guid KursId { get; set; }

        /// <summary>
        /// Datum kursa.
        /// </summary>
        public DateTime DatumKursa { get; set; }

        /// <summary>
        /// Valuta kursa.
        /// </summary>
        public string Valuta { get; set; } = string.Empty;

        /// <summary>
        /// Vrednost kursa.
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal Vrednost { get; set; }

        public ICollection<Uplata>? Uplate { get; set; }
    }
}
