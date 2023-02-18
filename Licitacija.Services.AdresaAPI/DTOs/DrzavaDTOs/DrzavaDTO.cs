using Licitacija.Services.AdresaAPI.DTOs.Adresa;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.AdresaAPI.DTOs.Drzava
{
    /// <summary>
    /// DTO za državu.
    /// </summary>
    public class DrzavaDto
    {
        /// <summary>
        /// ID države.
        /// </summary>
        public Guid DrzavaId { get; set; }

        /// <summary>
        ///Naziv države.
        /// </summary>
        public string DrzavaNaziv { get; set; } = string.Empty;

    }
}
