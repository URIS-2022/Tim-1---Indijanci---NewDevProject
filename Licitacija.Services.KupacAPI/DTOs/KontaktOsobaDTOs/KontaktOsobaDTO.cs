namespace Licitacija.Services.KupacAPI.DTOs.KontaktOsobaDTOs
{
    public class KontaktOsobaDTO
    {
        public Guid KontaktOsobaId { get; set; }

        public string KontaktOsobaIme { get; set; } = String.Empty;

        public string KontaktOsobaPrezime { get; set; } = String.Empty;

        public string Funkcija { get; set; } = String.Empty;

        public string Telefon { get; set; } = String.Empty;
    }
}
