using Licitacija.Services.KupacAPI.Entities;


namespace Licitacija.Services.KupacAPI.DTOs.PravnoLiceDTOs
{
    public class PravnoLiceDTO
    {
        public Guid KupacId { get; set; }

        public Guid PravnoLiceId { get; set; }

        public string PravnoLiceNazv { get; set; }

        public string MaticniBroj { get; set; }

        public string? Faks { get; set; }

        public KontaktOsoba? KontaktOsoba { get; set; }
    }
}
