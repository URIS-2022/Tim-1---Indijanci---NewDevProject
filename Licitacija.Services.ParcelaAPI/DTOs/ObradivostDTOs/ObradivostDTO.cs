namespace Licitacija.Services.ParcelaAPI.DTOs.ObradivostDTOs
{
    /// <summary>
    /// Model za prikaz obradivosti
    /// </summary>
    public class ObradivostDto

    {
        /// <summary>
        /// ID obradivosti
        /// </summary>
        public Guid ObradivostId { get; set; }

        /// <summary>
        /// Naziv oblika svojine
        /// </summary>
        public string ObradivostNaziv { get; set; }
    }
}
