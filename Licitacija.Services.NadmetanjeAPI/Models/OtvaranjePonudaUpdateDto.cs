using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model azuriranja otvaranja ponuda.
    /// </summary>
    public class OtvaranjePonudaUpdateDto
    {
        /// <summary>
        /// ID otvaranja ponuda.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID otvaranja ponuda.")]
        public Guid OtvaranjePonudaId { get; set; }

        /// <summary>
        /// ID nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID nadmetanja.")]
        public Guid NadmetanjeId { get; set; }
    }
}
