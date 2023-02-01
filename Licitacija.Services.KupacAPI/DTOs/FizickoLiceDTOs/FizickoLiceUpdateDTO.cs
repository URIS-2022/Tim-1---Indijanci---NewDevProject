using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.DTOs.FizickoLiceDTOs
{
    public class FizickoLiceUpdateDTO : IValidatableObject
    {
        [Required(ErrorMessage = "Obavezno je uneti ID kupca.")]
        public Guid KupacId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti ID FL.")]
        public Guid FizickoLiceId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti ime FL.")]
        [StringLength(35, ErrorMessage = "Maximum 35 karaktera prekoračeno")]
        public string FizickoLiceIme { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti prezime FL.")]
        [StringLength(35, ErrorMessage = "Maximum 35 karaktera prekoračeno")]
        public string FizickoLicePrezime { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti JMBG.")]
        public string JMBG { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FizickoLiceIme == FizickoLicePrezime)
            {
                yield return new ValidationResult(
                  "Fizicko lice ne sme imati istu vrednost za ime i prezime.",
                  new[] { "FizickoLiceCreateDTO" });

            }
            if (JMBG.Length != 13)
            {
                yield return new ValidationResult(
                 "JMBG mora imati tacno 13 cifara.",
                 new[] { "FizickoLiceCreateDTO" });
            }
        }
    }
}
