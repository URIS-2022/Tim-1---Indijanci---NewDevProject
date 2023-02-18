using System.Text.Json.Serialization;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model nadmetanja.
    /// </summary>
    public class NadmetanjeDto
    {
        /// <summary>
        /// ID nadmetanja.
        /// </summary>
        public Guid NadmetanjeId { get; set; }

        /// <summary>
        /// ID licitacija.
        /// </summary>
        [JsonIgnore]
        public Guid LicitacijaId { get; set; }

        /// <summary>
        /// ID katastarske opštine.
        /// </summary>
        [JsonIgnore]
        public Guid KatOpstinaId { get; set; }

        /// <summary>
        /// ID adrese.
        /// </summary>
        [JsonIgnore]
        public Guid AdresaId { get; set; }

        /// <summary>
        /// ID faze.
        /// </summary>
        [JsonIgnore]
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
        /// Objekat javnog nadmetanja.
        /// </summary>
        public JavnoDto? Javno { get; set; }

        /// <summary>
        /// Objekat otvaranja ponuda.
        /// </summary>
        public OtvaranjePonudaDto? OtvaranjePonuda { get; set; }

        /// <summary>
        /// Objekat statusa nadmetanja.
        /// </summary>
        public StatusNadmetanjaDto? StatusNadmetanja { get; set; }

        /// <summary>
        /// Objekat licitacije.
        /// </summary>
        public LicitacijaDto? Licitacija { get; set; }

        /// <summary>
        /// Objekat katastarske opštine.
        /// </summary>
        public KatastarskaOpstinaDto? KatastarskaOpstina { get; set; }

        /// <summary>
        /// Objekat adrese.
        /// </summary>
        public AdresaDto? Adresa { get; set; }

        /// <summary>
        /// Objekat faze.
        /// </summary>
        public FazaDto? Faza { get; set; }
    }
}
