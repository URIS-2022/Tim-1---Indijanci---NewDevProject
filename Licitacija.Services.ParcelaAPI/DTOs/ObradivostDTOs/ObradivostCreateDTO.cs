using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.ObradivostDTOs
{
    /// <summary>
    /// Model za kreiranje obradivosti
    /// </summary>
    public class ObradivostCreateDto
    {
        /// <summary>
        /// Naziv obradivosti
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv obradivosti parcele")]
        [StringLength(50, ErrorMessage = "Maximum 50 karaktera u nazivu")]
        public string OblikSvojineNaziv { get; set; } = String.Empty;
    }
}
