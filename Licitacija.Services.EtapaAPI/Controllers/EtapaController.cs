using AutoMapper;
using Licitacija.Services.EtapaAPI.DTOs.EtapaDTOs;
using Licitacija.Services.EtapaAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.EtapaAPI.Entities;
using Licitacija.Services.EtapaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.EtapaAPI.Controllers
{
    /// <summary>
    /// Etapa kontroler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class EtapaController : ControllerBase
    {
        private readonly IEtapaRepository _etapaRepository;
        private readonly IMapper _mapper;

        public EtapaController(IEtapaRepository etapaRepository, IMapper mapper)
        {
            _etapaRepository = etapaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve etape.
        /// </summary>
        /// <returns>Lista etapa.</returns>
        /// <response code="200">Vraća listu etapa.</response>
        /// <response code="204">Nema podataka u bazi.</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<EtapaDto>> GetAllEtape()
        {
            try
            {
                var etape = _etapaRepository.GetAll();

                if (etape == null || etape.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<EtapaDto>>(etape));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu etapu na osnovu ID-ja etape.
        /// </summary>
        /// <param name="id">ID etape</param>
        /// <returns>Jedna etapa.</returns>
        /// <response code="200">Vraća traženu etapu</response>
        /// <response code="404">Nije pronađena nijedna etapa sa datim ID etape</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EtapaDto> GetEtapa(Guid id)
        {
            try
            {
                var etapa = _etapaRepository.GetEtapa(id);

                if (etapa == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<EtapaDto>(etapa));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira nova etapa.
        /// </summary>
        /// <param name="etapaDTO">Model etape.</param>
        /// <returns>Potvrda o kreiranoj etapi.</returns>
        /// <response code="201">Vraća kreiranu etapu.</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EtapaDto> CreateEtapa([FromBody] EtapaCreateDto etapaDTO)
        {
            try
            {
                Etapa etapa = _mapper.Map<Etapa>(etapaDTO);
                _etapaRepository.InsertEtapa(etapa);
                _etapaRepository.Save();
                return Created("GetEtapa", _mapper.Map<EtapaDto>(etapa));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu etapu.
        /// </summary>
        /// <param name="etapaDTO">Model etape koja se ažurira.</param>
        /// <returns>Potvrdu o modifikovanoj etapi</returns>
        /// <response code="200">Vraća ažuriranu etapu</response>
        /// <response code="404">Etapa koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EtapaDto> UpdateEtapa([FromBody] EtapaUpdateDto etapaDTO)
        {
            try
            {
                var etapaToUpdate = _etapaRepository.GetEtapa(etapaDTO.EtapaId);

                if (etapaToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(etapaDTO, etapaToUpdate);
                _etapaRepository.Save();
                return Ok(_mapper.Map<EtapaDto>(etapaToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne etape na osnovu ID-ja etape.
        /// </summary>
        /// <param name="id">ID etape.</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Etapa uspešno obrisana.</response>
        /// <response code="404">Nije pronađena etapa za brisanje.</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteEtapa(Guid id)
        {
            try
            {
                var etapa = _etapaRepository.GetEtapa(id);

                if (etapa == null)
                {
                    return NotFound();
                }

                _etapaRepository.DeleteEtapa(id);
                _etapaRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vraća jednu etapu na osnovu ID-ja etape.
        /// </summary>
        /// <param name="id">ID etape</param>
        /// <returns>Jedna etapa.</returns>
        /// <response code="200">Vraća traženu etapu</response>
        /// <response code="404">Nije pronađena nijedna etapa sa datim ID etape</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("EtapaBasicInfo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EtapaBasicInfoDto> GetEtapaBasicInfo(Guid id)
        {
            try
            {
                var etapaBasicInfo = _etapaRepository.GetEtapaBasicInfo(id);

                if (etapaBasicInfo == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<EtapaBasicInfoDto>(etapaBasicInfo);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
