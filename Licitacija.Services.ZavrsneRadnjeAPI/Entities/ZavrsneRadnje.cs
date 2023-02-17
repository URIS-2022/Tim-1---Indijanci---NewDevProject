using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ZavrsneRadnjeAPI.Entities
{
    public class ZavrsneRadnje
    {
        /// <summary>
        /// ID zavrsne radnje.
        /// </summary>
        [Key]
        public Guid ZavrsnaRadnjaId { get; set; } 

        /// <summary>
        /// Naziv zavrsne radnje .
        /// </summary>
        [Required]
        public string ZavrsnaRadnjaNaziv { get; set; } = String.Empty;

        /// <summary>
        /// ID faze licitacije .
        /// </summary>
        public Guid? FazaId { get; set; }
    }
}
