using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.DokumentAPI.Models.TipGarancijeDtos
{
    public class NoviTipGarancijeDto
    {
        /// <summary>
        /// ID tipa garancije.
        /// </summary>
        public Guid TipGarancijeId { get; set; }

        /// <summary>
        /// Naziv tipa garancije.
        /// </summary>
        public string TipGarancijeNaziv { get; set; } = string.Empty;

    }
}
