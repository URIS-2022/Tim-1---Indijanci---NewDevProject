using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Licitacija.Services.LicitacijaAPI.Entities
{
    /// <summary>
    /// Entitet licitacija
    /// </summary>
    public class LicitacijaEntity
    {
        /// <summary>
        /// ID Licitacije
        /// </summary>
        [Key]
        public Guid LicitacijaId { get; set; } = new Guid();

        /// <summary>
        /// Broj icitacije
        /// </summary>
        public int Broj { get; set; }

        /// <summary>
        /// Godina licitacije
        /// </summary>
        public int Godina { get; set; }

        /// <summary>
        /// Datum licitacije
        /// </summary>
        public DateTime Datum { get; set; }

        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        public int Ogranicenje { get; set; }

        /// <summary>
        /// Korak cene licitacije
        /// </summary>
        public int KorakCene { get; set; }

        /// <summary>
        /// Rok za prijave licitacije
        /// </summary>
        public DateTime RokZaPrijave { get; set; }

        [JsonIgnore]
        public IList<FazaLicitacije> FazaLicitacije { get; set; }
    }
}

