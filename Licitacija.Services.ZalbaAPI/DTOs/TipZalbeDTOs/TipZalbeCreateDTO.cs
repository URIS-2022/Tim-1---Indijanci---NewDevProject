using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ZalbaAPI.DTOs.TipZalbeDTOs
{
    public class TipZalbeCreateDTO
    {
        /// <summary>
        /// Naziv tipa žalbe
        /// </summary>

        [Required(ErrorMessage = "Obavezno je uneti naziv žalbe.")]
        [StringLength(30, ErrorMessage = "Maximum 30 karaktera prekoračeno")]
        public string TipZalbeNaziv { get; set; } = String.Empty;
    }
}
