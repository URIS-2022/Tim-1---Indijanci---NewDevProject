using Licitacija.Services.KupacAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.DTOs.PravnoLiceDTOs
{
    public class PravnoLiceUpdateDTO
    {
        [Required(ErrorMessage = "Obavezno je uneti ID kupca.")]

        public Guid KupacId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti ID PL.")]
        public Guid PravnoLiceId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv PL.")]
        [StringLength(35, ErrorMessage = "Maximum 35 karaktera prekoračeno")]
        public string PravnoLiceNazv { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti maticni broj.")]
        public string MaticniBroj { get; set; }

        public string? Faks { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti ID kontakt osobe.")]
        public Guid KontaktOsobaId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MaticniBroj.Length != 8)
            {
                yield return new ValidationResult(
                 "Maticni broj mora imati tacno 8 cifara.",
                 new[] { "PravnoLiceCreateDTO" });
            }
        }
    }
}
