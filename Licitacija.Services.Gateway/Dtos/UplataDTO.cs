using Licitacija.Services.Gateway.Dtos;
using Newtonsoft.Json;

namespace Licitacija.Services.Gateway.Dtos
{
    public class UplataDto
    {
        public Guid UplataId { get; set; }

        public string BrojRacuna { get; set; } = string.Empty;

        public string PozivNaBroj { get; set; } = string.Empty;

        public decimal Iznos { get; set; }

        public string SvrhaUplate { get; set; } = string.Empty;

        public DateTime DatumUplate { get; set; }

        [JsonIgnore]
        public Guid KupacId { get; set; }

        public KupacDto? Kupac { get; set; }

        public KursDto? Kurs{ get; set; }

    }
}
