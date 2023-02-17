namespace Licitacija.Services.NadmetanjeAPI.Models
{
    public class JavnoUpdateDto
    {
        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        public Guid JavnoNadmetanjeId { get; set; }

        /// <summary>
        /// ID nadmetanja.
        /// </summary>
        public Guid NadmetanjeId { get; set; }

        /// <summary>
        /// ID etape.
        /// </summary>
        public Guid EtapaId { get; set; }
    }
}
