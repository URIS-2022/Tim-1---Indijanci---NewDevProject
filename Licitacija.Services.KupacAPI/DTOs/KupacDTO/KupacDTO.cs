using Licitacija.Services.KupacAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Licitacija.Services.KupacAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.KupacAPI.DTOs.PrioritetDTOs;
using Licitacija.Services.KupacAPI.DTOs.FizickoLiceDTOs;
using Licitacija.Services.KupacAPI.DTOs.PravnoLiceDTOs;

namespace Licitacija.Services.KupacAPI.DTOs.KupacDTO
{
    /// <summary>
    /// Model za izmenu kupca.
    /// </summary>
    public class KupacDto
    {
        /// <summary>
        /// ID kupca.
        /// </summary>
        public Guid KupacId { get; set; }

        /// <summary>
        /// Glavni broj telefona.
        /// </summary>
        public string BrojTel1 { get; set; }

        /// <summary>
        /// Dodatni broj telefona.
        /// </summary>
        public string? BrojTel2 { get; set; }

        /// <summary>
        /// Email adresa kupca.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// broj racuna.
        /// </summary>
        public string BrojRacuna { get; set; }

        /// <summary>
        /// Ostvarena povrsina.
        /// </summary>
        public int OstvarenPovrsina { get; set; }

        /// <summary>
        /// Indikator da li kupac ima zabranu.
        /// </summary>
        public bool ImaZabranu { get; set; }

        /// <summary>
        /// Ukoliko ima zabranu, datum njenog pocetja.
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Trajanje zabrane u godinama.
        /// </summary>
        public int? DuzinaTrajanjaZabrane { get; set; }

        /// <summary>
        /// Datum prestanka zabrane.
        /// </summary>
        public DateTime? DatumPrestankaZabrane { get; set; }

        /// <summary>
        /// Podaci o prioritetu.
        /// </summary>
        public PrioritetDto? Prioritet { get; set; }

        /// <summary>
        /// Podaci o fizickom licu.
        /// </summary>
        public FizickoLiceDto? FizickoLice { get; set; }

        /// <summary>
        /// Podaci o pravnom licu.
        /// </summary>
        public PravnoLiceDto? PravnoLice { get; set; }

        /// <summary>
        /// Adresa ID.
        /// </summary>
        [JsonIgnore]
        public Guid? AdresaId { get; set; }

        /// <summary>
        /// Podaci o adresi iz ms Adresa.
        /// </summary>
        public AdresaDto? Adresa { get; set; }
    }
}
