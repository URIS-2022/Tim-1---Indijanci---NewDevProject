using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.DTOs.PrioritetDTOs
{
    /// <summary>
    /// Model za izmenu prioriteta.
    /// </summary>
    public class PrioritetUpdateDto
    {
        /// <summary>
        /// ID prioriteta.
        /// </summary>
        public Guid PrioritetId { get; set; }

        /// <summary>
        ///Naziv prioriteta.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv prioriteta.")]
        [StringLength(100, ErrorMessage = "Maximum 100 karaktera prekoračeno")]
        public string PrioritetNaziv { get; set; } = String.Empty;
    }
}
