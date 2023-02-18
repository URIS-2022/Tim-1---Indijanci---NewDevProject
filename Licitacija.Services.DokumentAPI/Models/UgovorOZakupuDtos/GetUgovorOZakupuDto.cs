
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.ExchangeDtos;
using Newtonsoft.Json;

namespace Licitacija.Services.DokumentAPI.Models.UgovorOZakupuDtos
{
    public class GetUgovorOZakupuDto
    {
        /// <summary>
        /// ID ugovora o zakupu.
        /// </summary>
        public Guid UgovorOZakupuId { get; set; }

        /// <summary>
        /// ID dokumenta (strani kljuc).
        /// </summary>
        [JsonIgnore]
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
        [JsonIgnore]
        public Guid TipGarancijeId { get; set; }

        /// <summary>
        /// Tip garancije vezan za ugovor o zakupu.
        /// </summary>
        public TipGarancije TipGarancije { get; set; } = new TipGarancije();

        /// <summary>
        /// Strani kljuc prema entitetu Licnost iz Komisije.
        /// </summary>
        [JsonIgnore]
        public Guid LicnostId { get; set; }

        /// <summary>
        /// Strani kljuc prema entitetu Uplata iz Uplata mikroservisa.
        /// </summary>
        [JsonIgnore]
        public Guid UplataId { get; set; }

        /// <summary>
        /// Dokument koji predstavljau govor o zakupu.
        /// </summary>
        public Dokument? Dokument { get; set; }

        /// <summary>
        /// Uplata.
        /// </summary>
        public UplataDto? Uplata { get; set; }

        /// <summary>
        /// Licnost.
        /// </summary>
        public LicnostDto? Licnost { get; set; }
    }
}
