using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model kreiranja javnog nadmetanja.
    /// </summary>
    public class JavnoCreateDto
    {
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
