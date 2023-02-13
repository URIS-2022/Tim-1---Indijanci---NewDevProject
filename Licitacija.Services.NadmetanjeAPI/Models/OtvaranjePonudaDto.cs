namespace Licitacija.Services.NadmetanjeAPI.Models
{
    public class OtvaranjePonudaDto
    {
        public Guid OtvaranjePonudaId { get; set; }
        public NadmetanjeDto? Nadmetanje { get; set; }
    }
}
