using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Licitacija.Services.AdresaAPI.Entities
{
    [Index(nameof(DrzavaNaziv), IsUnique = true)]
    public class Drzava
    {
        /// <summary>
        /// ID države.
        /// </summary>
        [Key]
        public Guid DrzavaId { get; set; }

        /// <summary>
        /// Naziv države.
        /// </summary>
        public string DrzavaNaziv { get; set; } = string.Empty;
 
    }
}
