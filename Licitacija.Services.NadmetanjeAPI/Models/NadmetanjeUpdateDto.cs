namespace Licitacija.Services.NadmetanjeAPI.Models
{
    public class NadmetanjeUpdateDto
    {
        /// <summary>
        /// ID nadmetanja.
        /// </summary>
        public Guid NadmetanjeId { get; set; }

        /// <summary>
        /// ID licitacija.
        /// </summary>
        public Guid LicitacijaId { get; set; }

        /// <summary>
        /// ID katastarske opstine.
        /// </summary>
        public Guid KadOpstinaId { get; set; }

        /// <summary>
        /// ID adrese.
        /// </summary>
        public Guid AdresaId { get; set; }

        /// <summary>
        /// ID faze.
        /// </summary>
        public Guid FazaId { get; set; }

        /// <summary>
        /// Vreme početka.
        /// </summary>
        public DateTime VremePocetka { get; set; }

        /// <summary>
        /// Vreme kraja.
        /// </summary>
        public DateTime VremeKraja { get; set; }

        /// <summary>
        /// Cena po hektaru.
        /// </summary>
        public int CenaPoHektaru { get; set; }

        /// <summary>
        /// Da li je izuzeto.
        /// </summary>
        public bool Izuzeto { get; set; }

        /// <summary>
        /// Izlicitirana cena.
        /// </summary>
        public int IzlicitiranaCena { get; set; }

        /// <summary>
        /// Period zakupa.
        /// </summary>
        public int PeriodZakupa { get; set; }

        /// <summary>
        /// Broj učesnika.
        /// </summary>
        public int BrojUcesnika { get; set; }

        /// <summary>
        /// Visina dopune depozita.
        /// </summary>
        public int VisinaDopuneDepozita { get; set; }

        /// <summary>
        /// Krug.
        /// </summary>
        public int Krug { get; set; }
    }
}
