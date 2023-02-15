using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.NadmetanjeKupacAPI.Entities
{
    public class NadmetanjeKupacEntity
    {
        /// <summary>
        /// ID nadmetanjeKupac
        /// </summary>
        [Key]
        public Guid NadmetanjeKupacId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// ID  - strani kljuc
        /// </summary>
        [ForeignKey(nameof(OvlascenoLice))]
        public Guid? OvlascenoLiceId { get; set; }
        /// <summary>
        /// Objekat ovlasceno lice
        /// </summary>
        public OvlascenoLice OvlascenoLice { get; set; }

        /// <summary>
        /// Id kupca - veza sa mikroservisom Kupac 
        /// </summary>
        public Guid? KupacId { get; set; }

        /// <summary>
        /// Id nadmeranja - veza sa mikroservisom Nadmetanje 
        /// </summary>
        public Guid? NadmetanjeId { get; set; }
    }
}
