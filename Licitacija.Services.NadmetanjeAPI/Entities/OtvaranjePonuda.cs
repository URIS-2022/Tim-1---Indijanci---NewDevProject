using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.NadmetanjeAPI.Entities
{
    public class OtvaranjePonuda
    {
        [Key]
        public Guid OtvaranjePonudaId { get; set; }

        [ForeignKey("NadmetanjeId")]
        public Guid NadmetanjeId { get; set; }
    }
}
