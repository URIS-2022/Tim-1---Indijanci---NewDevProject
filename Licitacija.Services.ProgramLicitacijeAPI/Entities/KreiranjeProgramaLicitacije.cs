using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ProgramLicitacijeAPI.Entities
{
    public class KreiranjeProgramaLicitacije
    {
        /// <summary>
        /// Id  programa.
        /// </summary>
        [Key]
        public Guid ProgramId { get; set; }

        /// <summary>
        /// Naziv programa
        /// </summary>
        public string? ProgramNaziv { get; set; }

        /// <summary>
        /// Id  Faze licitacije (strani kljuc, mikroservis Licitacija).
        /// </summary>
        public Guid? FazaLicitacijeId { get; set; }
    }
}
