namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model etape.
    /// </summary>
    public class EtapaDto
    {
        /// <summary>
        /// ID etape.
        /// </summary>
        public Guid EtapaId { get; set; }

        /// <summary>
        /// Datum etape.
        /// </summary>
        public DateTime Datum { get; set; }
    }
}
