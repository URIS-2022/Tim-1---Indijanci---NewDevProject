using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.AdresaAPI.DTOs.Drzava
{
    /// <summary>
    /// Model za kreiranje države.
    /// </summary>
    public class DrzavaCreateDto
    {
        /// <summary>
        /// Naziv države.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv drzave.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string DrzavaNaziv { get; set; } = string.Empty;

    }
}
