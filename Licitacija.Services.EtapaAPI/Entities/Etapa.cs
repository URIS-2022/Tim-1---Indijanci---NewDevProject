using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.EtapaAPI.Entities
{
    /// <summary>
    /// Predstavlja model etapa
    /// </summary>
    public class Etapa
    {
        /// <summary>
        /// ID etape
        /// </summary>
        [Key]
        public Guid EtapaId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Datum prestanka zabrane.
        /// </summary>
        [Required]
        public DateTime Datum { get; set; }
    }
}
