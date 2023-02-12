using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.ZalbaAPI.Entities
{
    public class Zalba
    {

        /// <summary>
        /// ID žalbe
        /// </summary>
        [Key]
        public Guid ZalbaId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Datum podnosenja
        /// </summary>
        [Required]
        public DateTime DatumPodnosenja { get; set; }

        /// <summary>
        /// Datum resenja
        /// </summary>
        [Required]
        public DateTime DatumResenja { get; set; }

        /// <summary>
        /// Razlog zalbe
        /// </summary>
        [Required]
        public string RazlogZalbe { get; set; } = String.Empty;

        /// <summary>
        /// Obrazlozenje
        /// </summary>
        [Required]
        public string Obrazlozenje { get; set; } = String.Empty;

        /// <summary>
        /// Broj nadmetanja
        /// </summary>
        [Required]
        public string BrojNadmetanja { get; set; } = String.Empty;

        /// <summary>
        /// Broj odluke
        /// </summary>
        public string BrojOdluke { get; set; } = String.Empty;

        /// <summary>
        /// Broj resenja
        /// </summary>
        [Required]
        public string BrojResenja { get; set; } = String.Empty;

        /// <summary>
        /// ID statusa žalbe - strani kljuc
        /// </summary>
        [ForeignKey(nameof(StatusZalbe))]
        public Guid? StatusZalbeId { get; set; }

        /// <summary>
        /// Objekat statusa žalbe
        /// </summary>
        public StatusZalbe StatusZalbe { get; set; }
        /// <summary>
        /// ID tipa žalbe - strani kljuc
        /// </summary>
        [ForeignKey(nameof(TipZalbe))]
        public Guid? TipZalbeId { get; set; }
        /// <summary>
        /// Objekat tipa žalbe
        /// </summary>
        public TipZalbe TipZalbe { get; set; }
        /// <summary>
        /// ID radnje za žalbu - strani kljuc
        /// </summary>
        [ForeignKey(nameof(RadnjaNaOsnovuZalbe))]
        public Guid? RadnjaId { get; set; }
        /// <summary>
        /// Objekat radnje za žalbu
        /// </summary>
        public RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe { get; set; }

        /// <summary>
        /// Id kupca - veza sa mikroservisom Kupac 
        /// </summary>
        public Guid? KupacId { get; set; }

        /// <summary>
        /// Id faze - veza sa mikroservisom RazaLicitacije 
        /// </summary>
        public Guid? FazaId { get; set; }
    }

}
