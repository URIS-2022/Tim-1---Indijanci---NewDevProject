using Licitacija.Services.NadmetanjeAPI.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.NadmetanjeAPI.Entities
{
    public class Javno
    {
        [Key]
        public Guid JavnoNadmetanjeId { get; set; }

        [ForeignKey("NadmetanjeId")]
        public Guid NadmetanjeId { get; set; }

        [ForeignKey("EtapaId")]
        public Guid EtapaId { get; set; }
        public EtapaDto Etapa { get; set; }

        [JsonIgnore]
        public Nadmetanje Nadmetanje { get; set; }


    }
}
