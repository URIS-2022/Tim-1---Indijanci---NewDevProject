using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.ParcelaDTOs
{
    /// <summary>
    /// Model za kreiranje parcele
    /// </summary>
    public class ParcelaCreateDto : IValidatableObject
    {
        /// <summary>
        /// Povrsina parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti povrsinu parcele.")]
        public int Povrsina { get; set; }

        /// <summary>
        /// Broj parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj parcele.")]
        public string BrojParcele { get; set; } = String.Empty;

        /// <summary>
        /// Broj lista nepokretnosti
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj lista nepokretnosti.")]
        public string BrojListaNepokretnosti { get; set; } = String.Empty;

        /// <summary>
        /// Stvarno stanje kulture
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje za kulturu.")]
        public string KulturaStvStanje { get; set; } = String.Empty;

        /// <summary>
        /// Stvarno stanje klase
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje za klasu.")]
        public string KlasaStvStanje { get; set; } = String.Empty;

        /// <summary>
        /// Stvarno stanje obradivosti
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje za obradivost.")]
        public string ObradivostStvStanje { get; set; } = String.Empty;

        /// <summary>
        /// Stvarno stanje zasticene zone
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje za zasticenu zonu.")]
        public string ZZonaStvStanje { get; set; } = String.Empty;

        /// <summary>
        /// Stvarno stanje odvodnjavanja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje za odvodnjavanje.")]
        public string OdvodnjavanjeStvStanje { get; set; } = String.Empty;

        /// <summary>
        /// ID klase (strani kljuc).
        /// </summary>
        public Guid? KlasaId { get; set; }

        /// <summary>
        /// ID kulture (strani kljuc).
        /// </summary>
        public Guid? KulturaId { get; set; }

        /// <summary>
        /// ID oblik svojine (strani kljuc).
        /// </summary>
        public Guid? OblikSvojineId { get; set; }

        /// <summary>
        /// ID obradivost (strani kljuc).
        /// </summary>
        public Guid? ObradivostId { get; set; }

        /// <summary>
        /// ID odvodnjavanja (strani kljuc).
        /// </summary>
        public Guid? OdvodnjavanjeId { get; set; }

        /// <summary>
        /// ID katastarske opstine (strani kljuc).
        /// </summary>
        public Guid? KatOpstinaId { get; set; }

        /// <summary>
        /// ID kupca (iz ms Kupac).
        /// </summary>
        public Guid? KupacId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Povrsina <= 0)
            {
                yield return new ValidationResult(
                    "Nije moguce uneti 0 za povrsinu parcele.",
                    new[] { "ParcelaCreateDTO" });
            }
        }

    }
}
