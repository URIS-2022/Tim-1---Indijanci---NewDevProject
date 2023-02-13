using Newtonsoft.Json;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    public class NadmetanjeDto
    {
        public Guid NadmetanjeId { get; set; }

        [JsonIgnore]
        public Guid LicitacijaId { get; set; }

        [JsonIgnore]
        public Guid KadOpstinaId { get; set; }

        [JsonIgnore]
        public Guid AdresaId { get; set; }

        [JsonIgnore]
        public Guid FazaId { get; set; }

        public DateTime VremePocetka { get; set; }
        public DateTime VremeKraja { get; set; }
        public int CenaPoHektaru { get; set; }
        public bool Izuzeto { get; set; }
        public int IzlicitiranaCena { get; set; }
        public int PeriodZakupa { get; set; }
        public int BrojUcesnika { get; set; }
        public int VisinaDopuneDepozita { get; set; }
        public int Krug { get; set; }
        public JavnoDto? Javno { get; set; }
        public OtvaranjePonudaDto? OtvaranjePonuda { get; set; }
        public StatusNadmetanjaDto? StatusNadmetanja { get; set; }
        public LicitacijaDto? Licitacija { get; set; }
        public KatastarskaOpstinaDto? KatastarskaOpstina { get; set; }
        public AdresaDto? Adresa { get; set; }
        public FazaDto? Faza { get; set; }
    }
}
