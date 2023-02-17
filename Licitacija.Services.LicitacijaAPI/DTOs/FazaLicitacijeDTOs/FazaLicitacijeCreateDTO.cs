using Licitacija.Services.LicitacijaAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.LicitacijaAPI.DTOs.FazaLicitacijeDTOs
{
    /// <summary>
    /// Model za kreiranje faze licitacije.
    /// </summary>
    public class FazaLicitacijeCreateDto
    {
        /// <summary>
        /// Naziv faze Licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je naziv licitacije.")]
        [StringLength(70, ErrorMessage = "Maximum 70 karaktera prekoračeno")]
        public String FazaNaziv { get; set; } = String.Empty;

        /// <summary>
        /// ID Licitacije
        /// </summary>
        public Guid? LicitacijaId { get; set; }
    }
}
