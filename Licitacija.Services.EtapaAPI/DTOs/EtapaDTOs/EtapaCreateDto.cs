using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.EtapaAPI.DTOs.EtapaDTOs
{
    /// <summary>
    /// Model za kreiranje etape
    /// </summary>
    public class EtapaCreateDto
    {
        /// <summary>
        /// Datum
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum")]
        public DateTime Datum { get; set; }
    }
}
