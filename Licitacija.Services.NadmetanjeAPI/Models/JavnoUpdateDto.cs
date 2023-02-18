using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model azuriranje javnog nadmetanja.
    /// </summary>
    public class JavnoUpdateDto
    {
        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID javnog nadmetanja.")]
        public Guid JavnoNadmetanjeId { get; set; }

        /// <summary>
        /// ID nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID nadmetanja.")]
        public Guid NadmetanjeId { get; set; }

        /// <summary>
        /// ID etape.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID etape.")]
        public Guid EtapaId { get; set; }
    }
}
