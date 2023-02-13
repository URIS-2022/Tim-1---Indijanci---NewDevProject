namespace Licitacija.Services.Gateway.Dtos
{
    public class KupacDto
    {
        public Guid KupacId { get; set; }

        public string? BrojTel1 { get; set; }

        public string? Email { get; set; }

        public string? BrojRacuna { get; set; }

        public int OstvarenPovrsina { get; set; }

        public bool? ImaZabranu { get; set; }
    }
}
