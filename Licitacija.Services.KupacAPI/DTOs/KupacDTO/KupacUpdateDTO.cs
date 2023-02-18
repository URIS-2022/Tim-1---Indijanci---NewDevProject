using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.KupacAPI.DTOs.KupacDTO
{
    /// <summary>
    /// Model za izmenu kupca.
    /// </summary>
    public class KupacUpdateDto : IValidatableObject
    {
        /// <summary>
        /// ID kupca.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID kupca.")]
        public Guid KupacId { get; set; }

        /// <summary>
        /// Glavni broj telefona.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona.")]
        [StringLength(15, ErrorMessage = "Maximum 15 karaktera prekoračeno")]
        public string BrojTel1 { get; set; }

        /// <summary>
        /// Dodatni broj telefona.
        /// </summary>
        [StringLength(15, ErrorMessage = "Maximum 15 karaktera prekoračeno")]
        public string? BrojTel2 { get; set; }

        /// <summary>
        /// Email adresa kupca.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti email.")]
        public string Email { get; set; }

        /// <summary>
        /// broj racuna.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj racuna.")]
        public string BrojRacuna { get; set; }

        /// <summary>
        /// Ostvarena povrsina.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ostvarenu povrsinu.")]
        public int OstvarenPovrsina { get; set; }

        /// <summary>
        /// Indikator da li kupac ima zabranu.
        /// </summary>
        [Required(ErrorMessage = "Podatak o zabrani je obavezan.")]
        public bool ImaZabranu { get; set; }

        /// <summary>
        /// Ukoliko ima zabranu, datum njenog pocetja.
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Trajanje zabrane u godinama.
        /// </summary>
        public int? DuzinaTrajanjaZabrane { get; set; }

        /// <summary>
        /// Datum prestanka zabrane.
        /// </summary>
        public DateTime? DatumPrestankaZabrane { get; set; }

        /// <summary>
        /// Tip kupca (pravno ili fizicko lice).
        /// </summary>
        [Required(ErrorMessage = "Podatak o tipu kupca je obavezan.")]
        public string TipKupca { get; set; }

        /// <summary>
        /// Prioritet ID (strani kljuc).
        /// </summary>
        public Guid? PrioritetId { get; set; }

        /// <summary>
        /// ID adrese (iz ms Adresa).
        /// </summary>
        public Guid? AdresaId { get; set; }

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

            if (!TipKupca.ToLower().Equals("pravno") && !TipKupca.ToLower().Equals("fizicko"))
            {
                yield return new ValidationResult(
                  "Tip kupca uzima vrednost pravno ili fizicko.",
                  new[] { "KupacUpdateDTO" });
            }
        }
    }
}
