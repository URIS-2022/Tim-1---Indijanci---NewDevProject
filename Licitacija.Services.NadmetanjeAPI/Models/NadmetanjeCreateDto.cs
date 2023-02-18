using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model kreiranja nadmetanja.
    /// </summary>
    public class NadmetanjeCreateDto
    {
        /// <summary>
        /// ID licitacija.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID licitacije.")]
        public Guid LicitacijaId { get; set; }

        /// <summary>
        /// ID statusa nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID statusa nadmetanja.")]
        public Guid StatusNadmetanjaId { get; set; }

        /// <summary>
        /// ID katastarske opstine.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID katastarske opstine.")]
        public Guid KatOpstinaId { get; set; }

        /// <summary>
        /// ID adrese.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID adrese.")]
        public Guid AdresaId { get; set; }

        /// <summary>
        /// ID faze.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID adrese.")]
        public Guid FazaId { get; set; }

        /// <summary>
        /// Vreme početka.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti vreme pocetka.")]
        public DateTime VremePocetka { get; set; }

        /// <summary>
        /// Vreme kraja.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti vreme kraja.")]
        public DateTime VremeKraja { get; set; }

        /// <summary>
        /// Cena po hektaru.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti cenu po hektaru.")]
        public int CenaPoHektaru { get; set; }

        /// <summary>
        /// Da li je izuzeto.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti podataka da li je izuzeto.")]
        public bool Izuzeto { get; set; }

        /// <summary>
        /// Izlicitirana cena.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti izlicitiranu cenu.")]
        public int IzlicitiranaCena { get; set; }

        /// <summary>
        /// Period zakupa.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti period zakupa.")]
        public int PeriodZakupa { get; set; }

        /// <summary>
        /// Broj učesnika.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj ucesnika.")]
        public int BrojUcesnika { get; set; }

        /// <summary>
        /// Visina dopune depozita.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti visinu dopune depozita.")]
        public int VisinaDopuneDepozita { get; set; }

        /// <summary>
        /// Krug.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti krug.")]
        public int Krug { get; set; }
    }
}
