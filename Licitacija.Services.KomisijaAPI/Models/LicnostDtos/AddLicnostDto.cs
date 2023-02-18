﻿namespace Licitacija.Services.KomisijaAPI.Models.LicnostDtos
{
    public class AddLicnostDto
    {
        /// <summary>
        /// Ime ličnosti.
        /// </summary>
        public string? Ime { get; set; }

        /// <summary>
        /// Prezime ličnosti.
        /// </summary>
        public string? Prezime { get; set; }

        /// <summary>
        /// Funkcija ličnosti.
        /// </summary>
        public string? Funkcija { get; set; }
    }
}
