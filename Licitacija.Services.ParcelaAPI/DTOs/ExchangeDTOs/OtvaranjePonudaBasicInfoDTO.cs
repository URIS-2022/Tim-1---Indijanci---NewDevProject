namespace Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs
{
    /// <summary>
    /// DTO nadmetanje sa osnovnim informacijama
    /// </summary>
    public class OtvaranjePonudaBasicInfoDto
    {
        /// <summary>
        /// ID otvaranja ponuda.
        /// </summary>
        public Guid OtvaranjePonudaId { get; set; }

        /// <summary>
        /// ID nadmetanja.
        /// </summary>
        public Guid NadmetanjeId { get; set; }
    }
}
