namespace Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs
{
    /// <summary>
    /// DTO etapa sa osnovnim informacijama.
    /// </summary>
    public class EtapaBasicInfoDTO
    {
        /// <summary>
        /// ID etape
        /// </summary>
        public Guid EtapaId { get; set; }

        /// <summary>
        /// Datum
        /// </summary>
        public DateTime Datum { get; set; }
    }
}
