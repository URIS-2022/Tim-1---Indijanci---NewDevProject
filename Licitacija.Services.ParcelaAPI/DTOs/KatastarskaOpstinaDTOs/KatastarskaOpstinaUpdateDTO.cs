using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.KatastarskaOpstinaDTOs
{
    /// <summary>
    /// Model za azuriranje katastarske opstine
    /// </summary>
    public class KatastarskaOpstinaUpdateDto
    {
        /// <summary>
        /// ID katastarske opstine
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID katastarske opstine.")]
        public Guid KatOpstinaId { get; set; }

        /// <summary>
        /// Naziv katastarske opstine
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv katastarske opstine")]
        [StringLength(30, ErrorMessage = "Maximum 30 karaktera u nazivu")]
        public string KatOpstinaNaziv { get; set; } = String.Empty;
    }
}
