using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeKupacAPI.DTOs.OvlascenoLiceDTOs
{
    public class OvlascenoLiceUpdateDto
    {
        /// <summary>
        /// ID ovlasceno lice
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID ovlascenog lica.")]
        public Guid OvlascenoLiceId { get; set; }

        /// <summary>
        /// Ime
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ime ovlascenog lica.")]
        [StringLength(40, ErrorMessage = "Maximum 40 karaktera prekoračeno")]
        public string Ime { get; set; } = String.Empty;

        /// <summary>
        /// Prezime
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti prezime ovlascenog lice.")]
        [StringLength(40, ErrorMessage = "Maximum 40 karaktera prekoračeno")]
        public string Prezime { get; set; } = String.Empty;

        /// <summary>
        /// Broj pasosa
        /// </summary>

        [StringLength(9, ErrorMessage = "Maximum 9 karaktera prekoračeno")]
        public string BrojPasosa { get; set; } = String.Empty;

        /// <summary>
        /// JMBG
        /// </summary>

        [StringLength(13, ErrorMessage = "Maximum 13 karaktera prekoračeno")]
        public string JMBG { get; set; } = String.Empty;

        /// <summary>
        /// ID adrese (iz ms Adresa).
        /// </summary>
        public Guid? AdresaId { get; set; }
    }
}
