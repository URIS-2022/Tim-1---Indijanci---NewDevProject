using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs
{
    /// <summary>
    /// DTO predradnje nadmetanja.
    /// </summary>
    public class PredradnjeNadmetanjaDto
    {
        /// <summary>
        /// ID predradnje nadmetanja.
        /// </summary>
        public Guid PredradnjeNadmetanjaId { get; set; }

        /// <summary>
        /// Naziv predradnje nadmetanja.
        /// </summary>
        public string PredradnjeNadmetanjaNaziv { get; set; } = String.Empty;

        /// <summary>
        /// Id faze (strani kljuc).
        /// </summary>
        [JsonIgnore]
        public Guid? FazaId { get; set; }

        /// <summary>
        /// DTO faze za prikaz podataka o fazi.
        /// </summary>
        public FazaDto? Faza { get; set; }
    }
}
