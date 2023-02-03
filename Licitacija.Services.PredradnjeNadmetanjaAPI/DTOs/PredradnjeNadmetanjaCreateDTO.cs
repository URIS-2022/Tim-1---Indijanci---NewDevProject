using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs
{
    public class PredradnjeNadmetanjaCreateDTO
    {
        [Required(ErrorMessage = "Obavezno je uneti naziv predradnje.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string PredradnjeNadmetanjaNaziv { get; set; } = String.Empty;
    }
}
