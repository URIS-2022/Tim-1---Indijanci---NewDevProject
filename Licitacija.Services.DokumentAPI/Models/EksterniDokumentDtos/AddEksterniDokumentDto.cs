using Licitacija.Services.DokumentAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.DokumentAPI.Models.EksterniDokumentDtos
{
    public class AddEksterniDokumentDto
    {
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
