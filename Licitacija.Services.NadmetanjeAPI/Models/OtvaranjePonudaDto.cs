namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model otvaranja ponuda.
    /// </summary>
    public class OtvaranjePonudaDto
    {
        /// <summary>
        /// ID otvaranja ponuda.
        /// </summary>
        public Guid OtvaranjePonudaId { get; set; }

        /// <summary>
        /// ID objekat nadmetanja.
        /// </summary>
        public NadmetanjeDto? Nadmetanje { get; set; }
    }
}
