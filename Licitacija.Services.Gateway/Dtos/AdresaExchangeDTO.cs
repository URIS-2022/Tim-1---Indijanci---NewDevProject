namespace Licitacija.Services.Gateway.Dtos
{
    public class AdresaExchangeDTO
    {
        public Guid AdresaId { get; set; }

        public string Ulica { get; set; } = string.Empty;

        public string Broj { get; set; } = string.Empty;

        public string Mesto { get; set; } = string.Empty;

        public string PostanskiBroj { get; set; } = string.Empty;
    }
}
