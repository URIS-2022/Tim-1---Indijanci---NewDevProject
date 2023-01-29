using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.DTOs.KontaktOsobaDTOs
{
    public class KontaktOsobaCreateDTO : IValidatableObject
    {
        [Required(ErrorMessage = "Obavezno je uneti ime.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string KontaktOsobaIme { get; set; } = String.Empty;

        [Required(ErrorMessage = "Obavezno je uneti prezime.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string KontaktOsobaPrezime { get; set; } = String.Empty;

        [Required(ErrorMessage = "Obavezno je uneti funkciju.")]
        [StringLength(25, ErrorMessage = "Maximum 25 karaktera prekoračeno")]
        public string Funkcija { get; set; } = String.Empty;

        [Required(ErrorMessage = "Obavezno je uneti broj telefona.")]
        [StringLength(15, ErrorMessage = "Maximum 15 karaktera prekoračeno")]
        public string Telefon { get; set; } = String.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (KontaktOsobaIme == KontaktOsobaPrezime)
            {
                yield return new ValidationResult(
                  "Kontakt osoba ne sme imati istu vrednost za ime i prezime.",
                  new[] { "KontaktOsobaCreateDTO" });

            }
        }
    }
}
