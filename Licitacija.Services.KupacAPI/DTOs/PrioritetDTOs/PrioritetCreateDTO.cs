using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.DTOs.PrioritetDTOs
{
    /// <summary>
    /// Model za kreiranje prioriteta.
    /// </summary>
    public class PrioritetCreateDto
    {
        /// <summary>
        ///Naziv prioriteta.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv prioriteta.")]
        [StringLength(100, ErrorMessage = "Maximum 100 karaktera prekoračeno")]
        public string PrioritetNaziv { get; set; } = String.Empty;
    }
}
