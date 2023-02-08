using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.AdresaAPI.Entities
{
    public class Adresa
    {
        /// <summary>
        /// ID drzave.
        /// </summary>
        [Key]
        public Guid AdresaId { get; set; }

        /// <summary>
        /// Naziv ulice.
        /// </summary>
        public string Ulica { get; set; } = string.Empty;

        /// <summary>
        /// Broj kuće/stana.
        /// </summary>
        public string Broj { get; set; } = string.Empty;

        /// <summary>
        /// Naziv mesta.
        /// </summary>
        public string Mesto { get; set; } = string.Empty;

        /// <summary>
        /// Poštanski broj mesta.
        /// </summary>
        public string PostanskiBroj { get; set; } = string.Empty;

        /// <summary>
        /// Podaci o državi koja je strani ključ u entitetu adresa.
        /// </summary>
        [ForeignKey(nameof(Drzava))]
        public Guid? DrzavaId { get; set; }

        public Drzava? Drzava { get; set; }

    }
}
