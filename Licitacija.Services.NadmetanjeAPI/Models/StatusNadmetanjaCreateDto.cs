using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model kreiranja statusa nadmetanja.
    /// </summary>
    public class StatusNadmetanjaCreateDto
    {
        /// <summary>
        /// Naziv statusa nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv statusa nadmetanja.")]
        [StringLength(30, ErrorMessage = "Maximum 30 karaktera prekoračeno")]
        public string? StatusNadmetanjaNaziv { get; set; }
    }
}
