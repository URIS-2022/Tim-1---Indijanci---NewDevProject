namespace Licitacija.Services.UplataAPI.Models
{
    /// <summary>
    /// DTO za kurs.
    /// </summary>
    public class KursDto
    {
        /// <summary>
        /// ID kursa.
        /// </summary>
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
        public decimal Vrednost { get; set; }
    }
}
