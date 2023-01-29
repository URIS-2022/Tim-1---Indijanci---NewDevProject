using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.DTOs.PrioritetDTOs
{
    public class PrioritetCreateDTO
    {
        [Required(ErrorMessage = "Obavezno je uneti naziv prioriteta.")]
        [StringLength(100, ErrorMessage = "Maximum 100 karaktera prekoračeno")]
        public string PrioritetNaziv { get; set; } = String.Empty;
    }
}
