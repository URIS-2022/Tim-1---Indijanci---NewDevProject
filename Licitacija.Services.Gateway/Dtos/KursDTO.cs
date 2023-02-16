namespace Licitacija.Services.Gateway.Dtos
{
    public class KursDto
    {
        public Guid KursId { get; set; }

        public DateTime DatumKursa { get; set; }

        public string Valuta { get; set; } = string.Empty;

        public decimal Vrednost { get; set; }
    }
}
