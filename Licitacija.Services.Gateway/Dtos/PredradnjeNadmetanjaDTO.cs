using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Gateway.Dtos
{

    public class PredradnjeNadmetanjaDto
    {
        public Guid PredradnjeNadmetanjaId { get; set; }

        public string PredradnjeNadmetanjaNaziv { get; set; } = String.Empty;

        [JsonIgnore]
        public Guid? FazaId { get; set; }

        public FazaDto? Faza { get; set; }
    }
}
