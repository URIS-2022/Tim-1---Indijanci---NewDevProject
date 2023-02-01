using Licitacija.Services.KupacAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.DTOs.FizickoLiceDTOs
{
    public class FizickoLiceDTO
    {
        public Guid KupacId { get; set; }

        public Guid FizickoLiceId { get; set; }

        public string FizickoLiceIme { get; set; }

        public string FizickoLicePrezime { get; set; }

        public string JMBG { get; set; }
    }
}
