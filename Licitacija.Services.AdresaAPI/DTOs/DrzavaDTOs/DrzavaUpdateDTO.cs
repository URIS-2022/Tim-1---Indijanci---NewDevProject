using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.AdresaAPI.DTOs.Drzava
{
    /// <summary>
    /// Model za izmenu države.
    /// </summary>
    public class DrzavaUpdateDto
    {
        /// <summary>
        /// ID države.
        /// </summary>
        public Guid DrzavaId { get; set; }

        /// <summary>
        /// Naziv države.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv drzave.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string DrzavaNaziv { get; set; } = string.Empty;
    }
}
