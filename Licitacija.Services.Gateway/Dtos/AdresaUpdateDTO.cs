using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Gateway.Dtos
{
    public class AdresaUpdateDTO
    {
        public Guid AdresaId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv ulice.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string Ulica { get; set; } = string.Empty;


        [Required(ErrorMessage = "Obavezno je uneti broj kuce/stana.")]
        [StringLength(15, ErrorMessage = "Maximum 15 karaktera prekoračeno")]
        public string Broj { get; set; } = string.Empty;

        [Required(ErrorMessage = "Obavezno je uneti mesto stanovanja.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string Mesto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Obavezno je uneti postanski broj.")]
        [StringLength(15, ErrorMessage = "Maximum 15 karaktera prekoračeno")]
        public string PostanskiBroj { get; set; } = string.Empty;

        public Guid? DrzavaId { get; set; }
    }
}
