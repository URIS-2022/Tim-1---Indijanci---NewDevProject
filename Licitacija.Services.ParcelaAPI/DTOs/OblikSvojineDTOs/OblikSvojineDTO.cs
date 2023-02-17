namespace Licitacija.Services.ParcelaAPI.DTOs.OblikSvojineDTOs
{
    /// <summary>
    /// Model za prikaz oblika svojine
    /// </summary>
    public class OblikSvojineDto
    {
        /// <summary>
        /// ID oblika svojine
        /// </summary>
        public Guid OblikSvojineId { get; set; }

        /// <summary>
        /// Naziv oblika svojine
        /// </summary>
        public string OblikSvojineNaziv { get; set; }
    }
}
