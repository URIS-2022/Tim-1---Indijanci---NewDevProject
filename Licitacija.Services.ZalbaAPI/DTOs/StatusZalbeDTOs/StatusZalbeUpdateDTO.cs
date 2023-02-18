using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ZalbaAPI.DTOs.StatusZalbeDTOs
{
    public class StatusZalbeUpdateDto
    {
        /// <summary>
        /// ID statusa zalbe
        /// </summary>

        public Guid StatusZalbeId { get; set; }

        /// <summary>
        /// Naziv statusa žalbe 
        /// </summary>

        [Required(ErrorMessage = "Obavezno je uneti naziv statusa žalbe.")]
        [StringLength(30, ErrorMessage = "Maximum 30 karaktera prekoračeno")]
        public string StatusZalbeNaziv { get; set; } = String.Empty;
    }
}
