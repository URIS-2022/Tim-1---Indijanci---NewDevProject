using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.ParcelaAPI.DTOs.ParcelaDTOs;
using Newtonsoft.Json;

namespace Licitacija.Services.ParcelaAPI.DTOs.DeoParceleDTOs
{
    /// <summary>
    /// Model za prikaz dela parcele
    /// </summary>
    public class DeoParceleDto
    {
        /// <summary>
        /// ID dela parcele
        /// </summary>
        public Guid DeoParceleId { get; set; }

        /// <summary>
        /// povrsina dela parcele
        /// </summary>
        public int PovrsinaDelaParcele { get; set; }

        /// <summary>
        /// Podaci o parceli
        /// </summary>
        public ParcelaDto? Parcela { get; set; }

        /// <summary>
        /// Etapa ID
        /// </summary>
        [JsonIgnore]
        public Guid EtapaId { get; set; }

        /// <summary>
        /// Podaci o etapi iz ms Etapa
        /// </summary>
        public EtapaBasicInfoDto? Etapa { get; set; }

        /// <summary>
        /// Otvaranje ponuda ID
        /// </summary>
        [JsonIgnore]
        public Guid OtvaranjePonudaId { get; set; }

        /// <summary>
        /// Podaci o otvaranju ponuda iz ms Nadmetanje
        /// </summary>
        public OtvaranjePonudaBasicInfoDto? OtvaranjePonuda { get; set; }

    }
}
