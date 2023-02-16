using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ZavrsneRadnjeAPI.DTOs.ZavrsneRadnjeDto
{
    /// <summary>
    /// Model izmene zavrsne radnje.
    /// </summary>
    public class ZavrsneRadnjeUpdateDto
    {
        /// <summary>
        /// ID zavrsne radnje.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID.")]
        public Guid ZavrsnaRadnjaId { get; set; }

        /// <summary>
        /// Naziv zavrsne radnje.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv zavrsne radnje.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string ZavrsnaRadnjaNaziv { get; set; } = String.Empty;

        public Guid? FazaId { get; set; }
    }
}
