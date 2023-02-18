using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeAPI.Entities
{
    public class Nadmetanje
    {
        /// <summary>
        /// ID nadmetanja.
        /// </summary>
        [Key]
        public Guid NadmetanjeId { get; set; }

        /// <summary>
        /// ID licitacije.
        /// </summary>
        public Guid LicitacijaId { get; set; }

        /// <summary>
        /// ID katastarske opstine.
        /// </summary>
        public Guid KatOpstinaId { get; set; }

        /// <summary>
        /// ID statusa nadmetanja.
        /// </summary>
        public Guid? StatusNadmetanjaId { get; set; }

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

        /// <summary>
        /// Objekat statusa nadmetanja.
        /// </summary>
        public StatusNadmetanja? StatusNadmetanja { get; set; }

        /// <summary>
        /// Objekat javnog nadmetanja.
        /// </summary>
        public Javno? Javno { get; set; }

        /// <summary>
        /// Objekat otvaranja ponuda.
        /// </summary>
        public OtvaranjePonuda? OtvaranjePonuda { get; set; }

    }
}
