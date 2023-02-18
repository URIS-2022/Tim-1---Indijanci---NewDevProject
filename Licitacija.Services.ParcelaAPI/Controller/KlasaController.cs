using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.KlasaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ParcelaAPI.Controllers
{
    /// <summary>
    /// Klasa kontroler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class KlasaController : ControllerBase
    {
        private readonly IKlasaRepository _klasaRepository;
        private readonly IMapper _mapper;

        public KlasaController(IKlasaRepository klasaRepository, IMapper mapper)
        {
            _klasaRepository = klasaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve klase.
        /// </summary>
        /// <returns>Lista klasa.</returns>
        /// <response code="200">Vraća listu klasa</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<KlasaDto>> GetAllKlase()
        {
            try
            {
                var klase = _klasaRepository.GetAll();

                if (klase == null || klase.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<KlasaDto>>(klase));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu klasu na osnovu ID-ja klase.
        /// </summary>
        /// <param name="id">ID klase</param>
        /// <returns>Jedna klasa.</returns>
        /// <response code="200">Vraća traženu klasu</response>
        /// <response code="404">Nije pronađena nijedna klasa sa datim ID klase</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KlasaDto> GetKlasa(Guid id)
        {
            try
            {
                var klasa = _klasaRepository.GetKlasa(id);

                if (klasa == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<KlasaDto>(klasa));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira nova klasa
        /// </summary>
        /// <param name="klasaDTO">Model klase</param>
        /// <returns>Potvrda o kreiranoj klasi.</returns>
        /// <response code="201">Vraća kreiranu klasu</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KlasaDto> CreateKlasa([FromBody] KlasaCreateDto klasaDTO)
        {
            try
            {
                Klasa klasa = _mapper.Map<Klasa>(klasaDTO);
                _klasaRepository.InsertKlasa(klasa);
                _klasaRepository.Save();
                return Created("GetKlasa", _mapper.Map<KlasaDto>(klasa));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu klasu
        /// </summary>
        /// <param name="klasaDTO">Model klase koja se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj klasi</returns>
        /// <response code="200">Vraća ažuriranu klasu</response>
        /// <response code="404">Klasa koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KlasaDto> UpdateKlasa([FromBody] KlasaUpdateDto klasaDTO)
        {
            try
            {
                var klasaToUpdate = _klasaRepository.GetKlasa(klasaDTO.KlasaId);

                if (klasaToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(klasaDTO, klasaToUpdate);
                _klasaRepository.Save();
                return Ok(_mapper.Map<KlasaDto>(klasaToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne klase na osnovu ID-ja klase
        /// </summary>
        /// <param name="id">ID klase</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Klasa uspešno obrisana</response>
        /// <response code="404">Nije pronađena klasa za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteKlasa(Guid id)
        {
            try
            {
                var klasa = _klasaRepository.GetKlasa(id);

                if (klasa == null)
                {
                    return NotFound();
                }

                _klasaRepository.DeleteKlasa(id);
                _klasaRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}

