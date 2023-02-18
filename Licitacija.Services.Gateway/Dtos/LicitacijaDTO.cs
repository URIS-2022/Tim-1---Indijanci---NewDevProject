using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Gateway.Dtos
{
    public class LicitacijaDTO
    {
        public Guid LicitacijaId { get; set; }

        public int Broj { get; set; }

        public int Godina { get; set; }

        public DateTime Datum { get; set; }

        public int Ogranicenje { get; set; }

        public int KorakCene { get; set; }

        public DateTime RokZaPrijave { get; set; }
    }
}
