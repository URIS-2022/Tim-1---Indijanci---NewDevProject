using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.DokumentAPI.Entities
{
    public class UgovorOZakupu
    {
        /// <summary>
        /// ID ugovora o zakupu.
        /// </summary>
        [Key]
        public Guid UgovorOZakupuId { get; set; }

        /// <summary>
        /// ID dokumenta (strani kljuc).
        /// </summary>
        [Required]
        [ForeignKey(nameof(Dokument))]
        public Guid DokumentId { get; set; }

        /// <summary>
        /// Rokovi dospeća ugovora o zakupu.
        /// </summary>
        public int RokDospeca { get; set; }

        /// <summary>
        /// Rok za vracanje zemljista.
        /// </summary>
        [Required]
        public DateTime RokVracanjaZemljista { get; set; }

        /// <summary>
        /// Mesto potpisivanja.
        /// </summary>
        public string? MestoPotpisivanja { get; set; }

        /// <summary>
        /// Tip garancije Id (strani kljuc).
        /// </summary>
        [Required]
        [ForeignKey(nameof(TipGarancije))]
        public Guid TipGarancijeId { get; set; }

        /// <summary>
        /// Tip garancije vezan za ugovor o zakupu.
        /// </summary>
        public TipGarancije TipGarancije { get; set; } = new TipGarancije();

        /// <summary>
        /// Strani kljuc prema entitetu Licnost iz Komisije.
        /// </summary>
        public Guid LicnostId { get; set; }

        /// <summary>
        /// Strani kljuc prema entitetu Uplata iz Uplata mikroservisa.
        /// </summary>
        public Guid UplataId { get; set; }

        /// <summary>
        /// Dokument koji predstavljau govor o zakupu.
        /// </summary>
        public Dokument? Dokument { get; set; }

    }
}
