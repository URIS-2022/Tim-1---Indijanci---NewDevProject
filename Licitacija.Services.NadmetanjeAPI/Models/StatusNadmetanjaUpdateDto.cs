using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model azuriranja statusa nadmetanja.
    /// </summary>
    public class StatusNadmetanjaUpdateDto
    {
        /// <summary>
        /// ID statusa nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID statusa nadmetanja.")]
        public Guid StatusNadmetanjaId { get; set; }

        /// <summary>
        /// Naziv statusa nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv statusa nadmetanja.")]
        [StringLength(30, ErrorMessage = "Maximum 30 karaktera prekoračeno")]
        public string? StatusNadmetanjaNaziv { get; set; }
    }
}
