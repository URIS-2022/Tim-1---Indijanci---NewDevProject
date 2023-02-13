using Licitacija.Services.Gateway.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.Gateway.Dtos
{

    public class FazaLicitacijeDTO
    {

        public Guid FazaId { get; set; }

        public String FazaNaziv { get; set; }

        public LicitacijaDTO? Licitacija { get; set; }
    }
}
