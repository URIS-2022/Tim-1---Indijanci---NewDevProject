namespace Licitacija.Services.ParcelaAPI.DTOs.ZasticenaZonaDTOs
{
    /// <summary>
    /// Model za prikaz zasticene zone
    /// </summary>
    public class ZasticenaZonaDto
    {
        /// <summary>
        /// ID zasticene zone
        /// </summary>
        public Guid ZZonaId { get; set; }

        /// <summary>
        /// Naziv zasticene zone
        /// </summary>
        public string ZZonaNaziv { get; set; }
    }
}
