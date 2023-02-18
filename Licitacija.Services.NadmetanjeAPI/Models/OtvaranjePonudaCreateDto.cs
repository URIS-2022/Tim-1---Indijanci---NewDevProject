using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model kreiranja otvaranja ponuda.
    /// </summary>
    public class OtvaranjePonudaCreateDto
    {
        /// <summary>
        /// ID nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID nadmetanja.")]
        public Guid NadmetanjeId { get; set; }
    }
}
