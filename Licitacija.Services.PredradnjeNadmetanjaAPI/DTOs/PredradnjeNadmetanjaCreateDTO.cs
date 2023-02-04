using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs
{
    /// <summary>
    /// Model kreiranja predradnje nadmetanja.
    /// </summary>
    public class PredradnjeNadmetanjaCreateDTO
    {
        /// <summary>
        /// Naziv predradnje nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv predradnje.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string PredradnjeNadmetanjaNaziv { get; set; } = String.Empty;
    }
}
