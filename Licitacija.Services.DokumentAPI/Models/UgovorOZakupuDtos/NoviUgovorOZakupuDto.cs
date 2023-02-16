using Licitacija.Services.DokumentAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.DokumentAPI.Models.UgovorOZakupuDtos
{
    public class NoviUgovorOZakupuDto
    {
        /// <summary>
        /// ID ugovora o zakupu.
        /// </summary>
        public Guid UgovorOZakupuId { get; set; }

        /// <summary>
        /// ID dokumenta (strani kljuc).
        /// </summary>
        public Guid DokumentId { get; set; }

        /// <summary>
        /// Rokovi dospeća ugovora o zakupu.
        /// </summary>
        public int RokDospeca { get; set; }

        /// <summary>
        /// Rok za vracanje zemljista.
        /// </summary>
        public DateTime RokVracanjaZemljista { get; set; }

        /// <summary>
        /// Mesto potpisivanja.
        /// </summary>
        public string? MestoPotpisivanja { get; set; }

        /// <summary>
        /// Tip garancije Id (strani kljuc).
        /// </summary>
        public Guid TipGarancijeId { get; set; }

        /// <summary>
        /// Strani kljuc prema entitetu Licnost iz Komisije.
        /// </summary>
        public Guid LicnostId { get; set; }

        /// <summary>
        /// Strani kljuc prema entitetu Uplata iz Uplata mikroservisa.
        /// </summary>
        public Guid UplataId { get; set; }

    }
}
