namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Osnovni model nadmetanja.
    /// </summary>
    public class OtvaranjePonudaBasic
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
