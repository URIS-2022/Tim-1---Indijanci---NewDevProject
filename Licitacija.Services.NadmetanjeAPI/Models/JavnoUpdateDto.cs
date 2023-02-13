namespace Licitacija.Services.NadmetanjeAPI.Models
{
    public class JavnoUpdateDto
    {
        public Guid JavnoNadmetanjeId { get; set; }
        public Guid NadmetanjeId { get; set; }
        public Guid EtapaId { get; set; }
    }
}
