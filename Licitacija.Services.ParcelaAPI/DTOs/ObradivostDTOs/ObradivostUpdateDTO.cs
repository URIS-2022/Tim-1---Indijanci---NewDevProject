using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.ObradivostDTOs
{
    /// <summary>
    /// Model za azuriranje obradivosti
    /// </summary>
    public class ObradivostUpdateDto
    {
        /// <summary>
        /// ID obradivosti
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID obradivosti.")]
        public Guid ObradivostId { get; set; }

        /// <summary>
        /// Naziv obradivosti
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv obradivosti parcele")]
        [StringLength(50, ErrorMessage = "Maximum 50 karaktera u nazivu")]
        public string ObradivostNaziv { get; set; } = String.Empty;
    }
}
