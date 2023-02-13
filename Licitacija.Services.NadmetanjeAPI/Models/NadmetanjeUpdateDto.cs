namespace Licitacija.Services.NadmetanjeAPI.Models
{
    public class NadmetanjeUpdateDto
    {
        public Guid NadmetanjeId { get; set; }
        public Guid LicitacijaId { get; set; }
        public Guid KadOpstinaId { get; set; }
        public Guid AdresaId { get; set; }
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
    }
}
