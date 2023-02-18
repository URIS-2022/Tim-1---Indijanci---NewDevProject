using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.KatastarskaOpstinaDTOs
{
    /// <summary>
    /// Model za kreiranje katastarske opstine
    /// </summary>
    public class KatastarskaOpstinaCreateDto
    {
        /// <summary>
        /// Naziv katastarske opstine
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv katastarske opstine")]
        [StringLength(30, ErrorMessage = "Maximum 30 karaktera u nazivu")]
        public string KatOpstinaNaziv { get; set; } = String.Empty;

    }
}
