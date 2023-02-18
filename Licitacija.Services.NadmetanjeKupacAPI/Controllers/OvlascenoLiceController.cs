using AutoMapper;
using Licitacija.Services.NadmetanjeKupacAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.NadmetanjeKupacAPI.DTOs.OvlascenoLiceDTOs;
using Licitacija.Services.NadmetanjeKupacAPI.Entities;
using Licitacija.Services.NadmetanjeKupacAPI.Repositories.Interfaces;
using Licitacija.Services.NadmetanjeKupacAPI.ServiceCalls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.NadmetanjeKupacAPI.Controllers
{
    /// <summary>
    /// OvlascenoLice controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class OvlascenoLiceController : ControllerBase
    {
        private readonly IOvlascenoLiceRepository _ovlascenoLiceRepository;
        private readonly IAdresaService _adresaService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Zalba controller.
        /// </summary>
        public OvlascenoLiceController(IOvlascenoLiceRepository ovlascenoLiceRepository, IAdresaService adresaService, IMapper mapper)
        {
            _ovlascenoLiceRepository = ovlascenoLiceRepository;
            _adresaService = adresaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sva ovlascena lica.
        /// </summary>
        /// <returns>Lista ovlascenih lica.</returns>
        /// <response code="200">Vraća listu ovlascenih lica</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<OvlascenoLiceDto>> GetAllOvlascenoLice()
        {
            try
            {
                var ovlascenaLica = _ovlascenoLiceRepository.GetAll();

                if (ovlascenaLica == null || ovlascenaLica.Count == 0)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<OvlascenoLiceDto>>(ovlascenaLica);

                foreach (var ovlascenoLice in result)
                {

                    AdresaDto adresa = _adresaService.GetAdresaById(ovlascenoLice.AdresaId).Result;
                    ovlascenoLice.Adresa = adresa;


                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jedno ovlasceno lice na osnovu ID-ja ovlascenog lica.
        /// </summary>
        /// <param name="id">ID ovlascenog lica</param>
        /// <returns>Jedno ovlasceno lice.</returns>
        /// <response code="200">Vraća traženo ovlasceno lice</response>
        /// <response code="404">Nije pronađeno nijedno ovlasceno lice sa datim ID ovlascenog lica</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OvlascenoLiceDto> GetOvlascenoLice(Guid id)
        {
            try
            {
                var ovlascenoLice = _ovlascenoLiceRepository.GetOvlascenoLice(id);

                if (ovlascenoLice == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<OvlascenoLiceDto>(ovlascenoLice);

                AdresaDto adresa = _adresaService.GetAdresaById(result.AdresaId).Result;
                result.Adresa = adresa;

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novo ovlasceno lice.
        /// </summary>
        /// <param name="ovlascenoLiceDto">Model ovlascenog lica</param>
        /// <returns>Potvrda o kreiranom ovlascenom licu.</returns>
        /// <response code="201">Vraća kreirano ovlasceno lice</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OvlascenoLiceDto> CreateOvlascenoLice([FromBody] OvlascenoLiceCreateDto ovlascenoLiceDto)
        {
            try
            {
                OvlascenoLice ovlascenoLice = _mapper.Map<OvlascenoLice>(ovlascenoLiceDto);
                _ovlascenoLiceRepository.InsertOvlascenoLice(ovlascenoLice);
                _ovlascenoLiceRepository.Save();
                return Created("GetOvlascenoLice", _mapper.Map<OvlascenoLiceDto>(ovlascenoLice));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedno ovlasceno lice.
        /// </summary>
        /// <param name="ovlascenoLiceDto">Model ovlascenog lica koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom ovlascenom licu.</returns>
        /// <response code="200">Vraća ažurirano ovlasceno lice</response>
        /// <response code="404">Ovlasceno lice koja se ažurira nije pronađeno</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OvlascenoLiceDto> UpdateOvlascenoLice([FromBody] OvlascenoLiceUpdateDto ovlascenoLiceDto)
        {
            try
            {
                var ovlascenoLiceToUpdate = _ovlascenoLiceRepository.GetOvlascenoLice(ovlascenoLiceDto.OvlascenoLiceId);

                if (ovlascenoLiceToUpdate == null)
                {
                    return NotFound();
                }


                _mapper.Map(ovlascenoLiceDto, ovlascenoLiceToUpdate);
                _ovlascenoLiceRepository.Save();
                return Ok(_mapper.Map<OvlascenoLiceDto>(ovlascenoLiceToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog ovlascenog lici na osnovu ID-ja ovlascenog lica.
        /// </summary>
        /// <param name="id">ID ovlascenog lica</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Ovlasceno lice uspešno obrisano</response>
        /// <response code="404">Nije pronađeno ovlasceno lice za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteOvlascenoLice(Guid id)
        {
            try
            {
                var ovlascenoLice = _ovlascenoLiceRepository.GetOvlascenoLice(id);

                if (ovlascenoLice == null)
                {
                    return NotFound();
                }

                _ovlascenoLiceRepository.DeleteOvlascenoLice(id);
                _ovlascenoLiceRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
