namespace Licitacija.Services.EtapaAPI.DTOs.EtapaDTOs
{
    /// <summary>
    /// Model za prikaz etape
    /// </summary>
    public class EtapaDto
    {
        /// <summary>
        /// ID etape
        /// </summary>
        public Guid EtapaId { get; set; }

        /// <summary>
        /// Datum
        /// </summary>
        public DateTime Datum { get; set; }
    }
}
