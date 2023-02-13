using Licitacija.Services.KupacAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.DTOs.FizickoLiceDTOs
{
    /// <summary>
    /// Model fizickog lica.
    /// </summary>
    public class FizickoLiceDto
    {
        /// <summary>
        /// ID kupca (strani kljuc).
        /// </summary>
        public Guid KupacId { get; set; }

        /// <summary>
        /// ID fizickog lica.
        /// </summary>
        public Guid FizickoLiceId { get; set; }

        /// <summary>
        /// Ime fiizckog lica.
        /// </summary>
        public string FizickoLiceIme { get; set; }

        /// <summary>
        /// Prezime fizickog lica.
        /// </summary>
        public string FizickoLicePrezime { get; set; }

        /// <summary>
        /// Jedinstveni maticni broj gradjana.
        /// </summary>
        public string JMBG { get; set; }
    }
}
