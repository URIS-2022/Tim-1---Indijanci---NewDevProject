using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.EtapaAPI.DTOs.EtapaDTOs
{
    /// <summary>
    /// Model za azuriranje etape
    /// </summary>
    public class EtapaUpdateDto
    {
        /// <summary>
        /// ID etape
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID etape.")]
        public Guid EtapaId { get; set; }

        /// <summary>
        /// Datum
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum")]
        public DateTime Datum { get; set; }
    }
}
