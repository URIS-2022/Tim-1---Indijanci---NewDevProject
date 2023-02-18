using Licitacija.Services.DokumentAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.DokumentAPI.Models.EksterniDokumentDtos
{
    public class NoviEksterniDokumentDto
    {
        /// <summary>
        /// ID Eksternog dokumenta.
        /// </summary>
        public Guid EksterniDokumentId { get; set; }

        /// <summary>
        /// ID Dokumenta (strani kljuc).
        /// </summary>
        public Guid DokumentId { get; set; }

        /// <summary>
        /// Ustanova kojoj pripada eksterni dokument.
        /// </summary>
        public string Ustanova { get; set; } = string.Empty;
    }
}
