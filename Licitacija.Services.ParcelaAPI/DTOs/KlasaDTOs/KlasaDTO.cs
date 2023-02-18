namespace Licitacija.Services.ParcelaAPI.DTOs.KlasaDTOs
{
    /// <summary>
    /// Model za prikaz klase
    /// </summary>
    public class KlasaDto
    {
        /// <summary>
        /// ID klase
        /// </summary>
        public Guid KlasaId { get; set; }

        /// <summary>
        /// Naziv klase
        /// </summary>
        public string KlasaNaziv { get; set; }
    }
}
