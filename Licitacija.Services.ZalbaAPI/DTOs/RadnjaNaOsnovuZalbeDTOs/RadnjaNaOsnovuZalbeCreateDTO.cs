using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ZalbaAPI.DTOs.RadnjaNaOsnovuZalbeDTOs
{
    public class RadnjaNaOsnovuZalbeCreateDto
    {
        /// <summary>
        /// Naziv radnje za žalbu
        /// </summary>

        [Required(ErrorMessage = "Obavezno je uneti naziv radnje.")]
        [StringLength(30, ErrorMessage = "Maximum 30 karaktera prekoračeno")]
        public string RadnjaNaziv { get; set; } = String.Empty;
    }
}
