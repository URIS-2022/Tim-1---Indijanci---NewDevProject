using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.ParcelaDTOs
{
    /// <summary>
    /// Model za izmenu parcele
    /// </summary>
    public class ParcelaUpdateDto : IValidatableObject
    {
        /// <summary>
        /// ID parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID parcele.")]
        public Guid ParcelaId { get; set; }

        /// <summary>
        /// Povrsina parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti povrsinu parcele.")]
        public int Povrsina { get; set; }

        /// <summary>
        /// Broj parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj parcele.")]
        [StringLength(15, ErrorMessage = "Maximum unos 15 karaktera")]
        public string BrojParcele { get; set; }

        /// <summary>
        /// Broj lista nepokretnosti
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj liste nepokretnosti.")]
        [StringLength(15, ErrorMessage = "Maximum unos 15 karaktera")]
        public string BrojListaNepokretnosti { get; set; }

        /// <summary>
        /// Kultura stvarno stanje
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje kulture")]
        [StringLength(15, ErrorMessage = "Maximum unos 15 karaktera")]
        public string KulturaStvStanje { get; set; }

        /// <summary>
        /// Klasa stvarno stanje
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje klase")]
        [StringLength(15, ErrorMessage = "Maximum unos 15 karaktera")]
        public string KlasaStvStanje { get; set; }

        /// <summary>
        /// Obradivost stvarno stanje
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje obradivosti")]
        [StringLength(15, ErrorMessage = "Maximum unos 15 karaktera")]
        public string ObradivostStvStanje { get; set; }

        /// <summary>
        /// Zasticena zona stvarno stanje
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje zasticene zone")]
        [StringLength(15, ErrorMessage = "Maximum unos 15 karaktera")]
        public string ZZonaStvStanje { get; set; }

        /// <summary>
        /// Odvodnjavanje stvarno stanje
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje odvodnjavanja")]
        [StringLength(15, ErrorMessage = "Maximum unos 15 karaktera")]
        public string OdvodnjavanjeStvStanje { get; set; }

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
