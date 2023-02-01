using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.KupacAPI.Entities
{
    public class FizickoLice
    {
        [Required]
        [ForeignKey(nameof(Kupac))]
        public Guid KupacId { get; set; }

        public Guid FizickoLiceId { get; set; }

        [Required]
        public string FizickoLiceIme { get; set; }

        [Required]
        public string FizickoLicePrezime { get; set; }

        [Required]
        public string JMBG { get; set; }    
    }
}
