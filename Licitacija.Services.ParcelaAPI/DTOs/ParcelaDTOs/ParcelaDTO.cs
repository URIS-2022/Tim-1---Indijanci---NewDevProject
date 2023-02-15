﻿using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.ParcelaAPI.DTOs.KatastarskaOpstinaDTOs;
using Licitacija.Services.ParcelaAPI.DTOs.KlasaDTOs;
using Licitacija.Services.ParcelaAPI.DTOs.KulturaDTOs;
using Licitacija.Services.ParcelaAPI.DTOs.OblikSvojineDTOs;
using Licitacija.Services.ParcelaAPI.DTOs.ObradivostDTOs;
using Licitacija.Services.ParcelaAPI.DTOs.OdvodnjavanjeDTOs;
using Newtonsoft.Json;

namespace Licitacija.Services.ParcelaAPI.DTOs.ParcelaDTOs
{
    /// <summary>
    /// Model za prikaz parcele
    /// </summary>
    public class ParcelaDTO
    {
        /// <summary>
        /// ID parcele
        /// </summary>
        public Guid ParcelaId { get; set; }

        /// <summary>
        /// Povrsina parcele
        /// </summary>
        public int Povrsina { get; set; }

        /// <summary>
        /// Broj parcele
        /// </summary>
        public string BrojParcele { get; set; }

        /// <summary>
        /// Broj lista nepokretnosti
        /// </summary>
        public string BrojListaNepokretnosti { get; set; }

        /// <summary>
        /// Kultura stvarno stanje
        /// </summary>
        public string KulturaStvStanje { get; set; }

        /// <summary>
        /// Klasa stvarno stanje
        /// </summary>
        public string KlasaStvStanje { get; set; }

        /// <summary>
        /// Obradivost stvarno stanje
        /// </summary>
        public string ObradivostStvStanje { get; set; }

        /// <summary>
        /// Zasticena zona stvarno stanje
        /// </summary>
        public string ZZonaStvStanje { get; set; }

        /// <summary>
        /// Odvodnjavanje stvarno stanje
        /// </summary>
        public string OdvodnjavanjeStvStanje { get; set; }

        /// <summary>
        /// Podaci o klasi
        /// </summary>
        public KlasaDTO? Klasa { get; set; }

        /// <summary>
        /// Podaci o kulturi
        /// </summary>
        public KulturaDTO? Kultura { get; set; }

        /// <summary>
        /// Podaci o obliku svojine
        /// </summary>
        public OblikSvojineDTO? OblikSvojine { get; set; }

        /// <summary>
        /// Podaci o obradivosti
        /// </summary>
        public ObradivostDTO? Obradivost { get; set; }

        /// <summary>
        /// Podaci o odvodnjavanju
        /// </summary>
        public OdvodnjavanjeDTO? Odvodnjavanje { get; set; }

        /// <summary>
        /// Podaci o katastarskoj opstini
        /// </summary>
        public KatastarskaOpstinaDTO? KatastarskaOpstina { get; set; }

        /// <summary>
        /// Adresa ID
        /// </summary>
        [JsonIgnore]
        public Guid KupacId { get; set; }

        /// <summary>
        /// Podaci o kupcu iz ms Kupac
        /// </summary>
        public KupacBasicInfoDTO? Kupac { get; set; }
    }
}
