using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ZalbaAPI.DTOs.ZalbaDTOs
{
    public class ZalbaUpdateDto
    {
        /// <summary>
        /// ID žalbe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID kupca.")]
        public Guid ZalbaId { get; set; }

        /// <summary>
        /// Datum podnosenja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum podnosenja.")]
        public DateTime DatumPodnosenja { get; set; }

        /// <summary>
        /// Datum resenja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum resenja.")]
        public DateTime DatumResenja { get; set; }

        /// <summary>
        /// Razlog zalbe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti razlog zalbe.")]
        [StringLength(80, ErrorMessage = "Maximum 80 karaktera prekoračeno")]
        public string RazlogZalbe { get; set; } = String.Empty;

        /// <summary>
        /// Obrazlozenje
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti obrazlozenje.")]
        [StringLength(80, ErrorMessage = "Maximum 80 karaktera prekoračeno")]
        public string Obrazlozenje { get; set; } = String.Empty;

        /// <summary>
        /// Broj nadmetanja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj nadmetanja.")]
        [StringLength(40, ErrorMessage = "Maximum 40 karaktera prekoračeno")]
        public string BrojNadmetanja { get; set; } = String.Empty;

        /// <summary>
        /// Broj resenja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj resenja.")]
        [StringLength(40, ErrorMessage = "Maximum 40 karaktera prekoračeno")]
        public string BrojResenja { get; set; } = String.Empty;

        /// <summary>
        /// Broj odluke
        /// </summary>
        [StringLength(40, ErrorMessage = "Maximum 40 karaktera prekoračeno")]
        public string BrojOdluke { get; set; } = String.Empty;

        /// <summary>
        /// StatusZalbe ID (strani kljuc).
        /// </summary>
        public Guid? StatusZalbeId { get; set; }

        /// <summary>
        /// TipZalbe ID (strani kljuc).
        /// </summary>
        public Guid? TipZalbeId { get; set; }
        /// <summary>
        /// RadnjaNaOsnovuZalbe ID (strani kljuc).
        /// </summary>
        public Guid? RadnjaId { get; set; }

        /// <summary>
        /// ID kupca (iz ms Kupac).
        /// </summary>
        public Guid? KupacId { get; set; }
        /// <summary>
        /// ID faze (iz ms FazaLicitacije).
        /// </summary>
        public Guid? FazaId { get; set; }
    }
}
