using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.KlasaDTOs
{
    /// <summary>
    /// Model za kreiranje klase
    /// </summary>
    public class KlasaCreateDto
    {
        /// <summary>
        /// Naziv klase
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv klase parcele")]
        [StringLength(50, ErrorMessage = "Maximum 50 karaktera u nazivu")]
        public string KlasaNaziv { get; set; } = String.Empty;
    }
}
