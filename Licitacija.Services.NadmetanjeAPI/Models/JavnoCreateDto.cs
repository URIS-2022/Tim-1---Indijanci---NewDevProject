using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    public class JavnoCreateDto
    {
        public Guid NadmetanjeId { get; set; }
        public Guid EtapaId { get; set; }
    }
}
