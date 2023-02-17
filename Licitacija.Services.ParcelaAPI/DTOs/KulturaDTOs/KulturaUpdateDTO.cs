using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.KulturaDTOs
{
    /// <summary>
    /// Model za azuriranje kulture
    /// </summary>
    public class KulturaUpdateDto
    {
        /// <summary>
        /// ID kulture
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID kulture.")]
        public Guid KulturaId { get; set; }

        /// <summary>
        /// Naziv kulture
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv kulture parcele")]
        [StringLength(50, ErrorMessage = "Maximum 50 karaktera u nazivu")]
        public string KulturaNaziv { get; set; } = String.Empty;
    }
}
