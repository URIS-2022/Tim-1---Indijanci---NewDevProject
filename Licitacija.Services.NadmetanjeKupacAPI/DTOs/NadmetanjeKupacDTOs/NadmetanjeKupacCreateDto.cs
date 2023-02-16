using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeKupacAPI.DTOs.NadmetanjeKupacDTOs
{
    public class NadmetanjeKupacCreateDto
    {

        /// <summary>
        /// OvlascenoLice ID (strani kljuc).
        /// </summary>
        public Guid? OvlascenoLiceId { get; set; }

        /// <summary>
        /// ID nadmetanja (iz ms Nadmetanje).
        /// </summary>
        public Guid? NadmetanjeId { get; set; }

        /// <summary>
        /// ID kupca (iz ms Kupac).
        /// </summary>
        public Guid? KupacId { get; set; }
    }
}
