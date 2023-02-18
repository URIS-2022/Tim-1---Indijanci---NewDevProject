using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.ZasticenaZonaDTOs
{
    /// <summary>
    /// Model za kreiranje zasticene zone
    /// </summary>
    public class ZasticenaZonaCreateDto
    {
        /// <summary>
        /// Naziv zasticene zone
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv zasticene zone parcele")]
        [StringLength(70, ErrorMessage = "Maximum 70 karaktera u nazivu")]
        public string ZZonaNaziv { get; set; } = String.Empty;
    }
}
