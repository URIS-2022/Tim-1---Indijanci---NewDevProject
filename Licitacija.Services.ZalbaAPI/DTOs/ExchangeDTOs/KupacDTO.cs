﻿namespace Licitacija.Services.ZalbaAPI.DTOs.ExchangeDTOs
{
    public class KupacDTO
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
        public bool? ImaZabranu { get; set; }
    }
}
