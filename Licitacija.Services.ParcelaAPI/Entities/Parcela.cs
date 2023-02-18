using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.ParcelaAPI.Entities
{
    /// <summary>
    /// Predstavlja model za parcelu
    /// </summary>
    public class Parcela
    {
        /// <summary>
        /// ID parcele
        /// </summary>
        [Key]
        public Guid ParcelaId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// povrsina parcele
        /// </summary>
        [Required]
        public int Povrsina { get; set; }

        /// <summary>
        /// broj parcele
        /// </summary>
        [Required]
        public string BrojParcele { get; set; } = String.Empty;

        /// <summary>
        /// broj lista nepokretnosti
        /// </summary>
        [Required]
        public string BrojListaNepokretnosti { get; set; } = String.Empty;

        /// <summary>
        /// kultura stvarno stanje
        /// </summary>
        [Required]
        public string KulturaStvStanje { get; set; } = String.Empty;

        /// <summary>
        /// klasa stvarno stanje
        /// </summary>
        [Required]
        public string KlasaStvStanje { get; set; } = String.Empty;

        /// <summary>
        /// obradivost stvarno stanje
        /// </summary>
        [Required]
        public string ObradivostStvStanje { get; set; } = String.Empty;

        /// <summary>
        /// zasticena zona stvarno stanje
        /// </summary>
        [Required]
        public string ZZonaStvStanje { get; set; } = String.Empty;

        /// <summary>
        /// odvodnjavanje stvarno stanje
        /// </summary>
        [Required]
        public string OdvodnjavanjeStvStanje { get; set; } = String.Empty;

        [ForeignKey(nameof(Odvodnjavanje))]
        public Guid OdvodnjavanjeId { get; set; }

        public Odvodnjavanje? Odvodnjavanje { get; set; }

        [ForeignKey(nameof(Kultura))]
        public Guid KulturaId { get; set; }

        public Kultura? Kultura { get; set; }

        [ForeignKey(nameof(Klasa))]
        public Guid KlasaId { get; set; }

        public Klasa? Klasa { get; set; }

        [ForeignKey(nameof(Obradivost))]
        public Guid ObradivostId { get; set; }

        public Obradivost? Obradivost { get; set; }

        [ForeignKey(nameof(OblikSvojine))]
        public Guid OblikSvojineId { get; set; }

        public OblikSvojine? OblikSvojine { get; set; }

        [ForeignKey(nameof(KatastarskaOpstina))]
        public Guid KatOpstinaId { get; set; }

        public KatastarskaOpstina? KatastarskaOpstina { get; set; }

        /// <summary>
        /// Parcele
        /// </summary>
        [JsonIgnore]
        public IList<DeoParcele> DeloviParcele { get; set; }

        /// <summary>
        /// Povrsine
        /// </summary>
        [JsonIgnore]
        public IList<Povrsina> Povrsine { get; set; }

        /// <summary>
        /// ID kupca iz ms Kupac
        /// </summary>
        public Guid KupacId { get; set; }


    }
}
