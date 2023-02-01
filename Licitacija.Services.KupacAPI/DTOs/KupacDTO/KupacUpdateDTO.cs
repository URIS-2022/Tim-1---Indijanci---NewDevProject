using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.KupacAPI.DTOs.KupacDTO
{
    public class KupacUpdateDTO : IValidatableObject
    {
        [Required(ErrorMessage = "Obavezno je uneti ID kupca.")]
        public Guid KupacId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti broj telefona.")]
        [StringLength(15, ErrorMessage = "Maximum 15 karaktera prekoračeno")]
        public string BrojTel1 { get; set; }

        [StringLength(15, ErrorMessage = "Maximum 15 karaktera prekoračeno")]
        public string? BrojTel2 { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti broj racuna.")]
        public string BrojRacuna { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti ostvarenu povrsinu.")]
        public int OstvarenPovrsina { get; set; }

        [Required(ErrorMessage = "Podatak o zabrani je obavezan.")]
        public bool ImaZabranu { get; set; }

        public DateTime? DatumPocetkaZabrane { get; set; }

        public int? DuzinaTrajanjaZabrane { get; set; }

        public DateTime? DatumPrestankaZabrane { get; set; }

        public Guid? PrioritetId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Regex.IsMatch(Email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                yield return new ValidationResult(
                  "Pogresan format email adrese (primer: email@gmail.com).",
                  new[] { "KupacUpdateDTO" });
            }
        }
    }
}
