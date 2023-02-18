using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.OblikSvojineDTOs
{
    /// <summary>
    /// Model za azuriranje oblika svojine
    /// </summary>
    public class OblikSvojineUpdateDto
    {
        /// <summary>
        /// ID oblika svojine
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID oblika svojine.")]
        public Guid OblikSvojineId { get; set; }

        /// <summary>
        /// Naziv oblika svojine
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv oblika svojine parcele")]
        [StringLength(50, ErrorMessage = "Maximum 50 karaktera u nazivu")]
        public string OblikSvojineNaziv { get; set; } = String.Empty;
    }
}
