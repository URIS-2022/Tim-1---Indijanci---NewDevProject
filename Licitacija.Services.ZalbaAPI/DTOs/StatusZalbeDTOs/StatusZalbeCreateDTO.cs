using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ZalbaAPI.DTOs.StatusZalbeDTOs
{
    public class StatusZalbeCreateDto
    {
        /// <summary>
        /// Naziv statusa žalbe 
        /// </summary>

        [Required(ErrorMessage = "Obavezno je uneti naziv statusa žalbe.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string StatusZalbeNaziv { get; set; } = String.Empty;
    }
}
