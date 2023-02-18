namespace Licitacija.Services.ParcelaAPI.DTOs.KulturaDTOs
{
    /// <summary>
    /// Model za prikaz kulture
    /// </summary>
    public class KulturaDto
    {
        /// <summary>
        /// ID kulture
        /// </summary>
        public Guid KulturaId { get; set; }

        /// <summary>
        /// Naziv kulture
        /// </summary>
        public string KulturaNaziv { get; set; }
    }
}
