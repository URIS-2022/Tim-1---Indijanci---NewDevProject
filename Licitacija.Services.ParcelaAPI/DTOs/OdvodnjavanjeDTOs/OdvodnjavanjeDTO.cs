namespace Licitacija.Services.ParcelaAPI.DTOs.OdvodnjavanjeDTOs
{
    /// <summary>
    /// Model za prikaz odvodnjavanja
    /// </summary>
    public class OdvodnjavanjeDto
    {
        /// <summary>
        /// ID odvodnjavanja
        /// </summary>
        public Guid OdvodnjavanjeId { get; set; }

        /// <summary>
        /// Naziv odvodnjavanja
        /// </summary>
        public string OdvNaziv { get; set; }
    }
}
