using Newtonsoft.Json;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    public class JavnoDto
    {
        public Guid JavnoNadmetanjeId { get; set; }
        public NadmetanjeDto? Nadmetanje { get; set; }

        [JsonIgnore]
        public Guid EtapaId { get; set; }
        public EtapaDto? Etapa { get; set; }
    }
}
