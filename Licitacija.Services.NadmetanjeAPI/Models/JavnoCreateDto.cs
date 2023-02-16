using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    public class JavnoCreateDto
    {
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
