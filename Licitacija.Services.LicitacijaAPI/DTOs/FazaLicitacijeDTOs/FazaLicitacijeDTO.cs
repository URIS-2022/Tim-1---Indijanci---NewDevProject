using Licitacija.Services.LicitacijaAPI.DTOs.LicitacijaDTOs;
using Licitacija.Services.LicitacijaAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.LicitacijaAPI.DTOs.FazaLicitacijeDTOs
{
    /// <summary>
    /// Entitet faze licitacija
    /// </summary>
    public class FazaLicitacijeDto
    {
        /// <summary>
        /// ID faze licitacije
        /// </summary>
        public Guid FazaId { get; set; }

        /// <summary>
        /// Naziv faze Licitacije
        /// </summary>
        public String FazaNaziv { get; set; }

        /// <summary>
        /// DTO objekat Licitacije
        /// </summary>
        public LicitacijaDto? Licitacija { get; set; }
    }
}
