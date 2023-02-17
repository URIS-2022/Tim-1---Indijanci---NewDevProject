using AutoMapper;
using Licitacija.Services.LicitacijaAPI.Entities;
using Licitacija.Services.LicitacijaAPI.DTOs;
using Licitacija.Services.LicitacijaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Licitacija.Services.LicitacijaAPI.Repositories.Interface;
using Licitacija.Services.LicitacijaAPI.DTOs.LicitacijaDTOs;
using Licitacija.Services.LicitacijaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.LicitacijaAPI.Controllers
{
    /// <summary>
    /// Licitacija controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class LicitacijaController : ControllerBase
    {
        private readonly ILicitacija _licitacija;
        private readonly IMapper _mapper;

        /// <summary>
        /// Licitacija controller.
        /// </summary>

        public LicitacijaController(ILicitacija licitacija, IMapper mapper)
        {
            _licitacija = licitacija;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve licitacije.
        /// </summary>
        /// <returns>Lista licitacija.</returns>
        /// <response code="200">Vraća listu licitacija</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<LicitacijaDto>> GetAllLicitacije()
        {
            try
            {
                var licitacije = _licitacija.GetAll();

                if (licitacije == null || licitacije.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<LicitacijaDto>>(licitacije));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jedanu licitaciju na osnovu ID-ja licitacije.
        /// </summary>
        /// <param name="id">ID licitacije</param>
        /// <returns>Jedna licitacija.</returns>
        /// <response code="200">Vraća traženu licitaciju</response>
        /// <response code="404">Nije pronađena nijedna licitacija sa datim ID licitacija</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicitacijaDto> GetLicitacija(Guid id)
        {
            try
            {
                var licitacija = _licitacija.GetLicitacija(id);

                if (licitacija == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<LicitacijaDto>(licitacija));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novu licitaciju.
        /// </summary>
        /// <param name="licitacijaDTO">Model licitacije</param>
        /// <returns>Potvrda o kreiranoj licitaciji.</returns>
        /// <response code="201">Vraća kreiranu licitaciju</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicitacijaDto> Createlicitacija([FromBody] LicitacijaCreateDto licitacijaDTO)
        {
            try
            {
                LicitacijaEntity licitacija = _mapper.Map<LicitacijaEntity>(licitacijaDTO);
                _licitacija.InsertLicitacija(licitacija);
                _licitacija.Save();
                return Created("GetLicitacija", _mapper.Map<LicitacijaDto>(licitacija));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu licitaciju.
        /// </summary>
        /// <param name="licitacijaDTO">Model licitacije koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj licitaciji.</returns>
        /// <response code="200">Vraća ažuriranu licitaciju</response>
        /// <response code="404">licitacija koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicitacijaDto> UpdateLicitacija([FromBody] LicitacijaUpdateDto licitacijaDTO)
        {
            try
            {
                var licitacijaToUpdate = _licitacija.GetLicitacija(licitacijaDTO.LicitacijaId);

                if (licitacijaToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(licitacijaDTO, licitacijaToUpdate);
                _licitacija.Save();
                return Ok(_mapper.Map<LicitacijaDto>(licitacijaToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne licitacija na osnovu ID-ja licitacije.
        /// </summary>
        /// <param name="id">ID licitacije</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Licitacija je uspesno obrisana</response>
        /// <response code="404">Nije pronađena licitacija za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteLicitacija(Guid id)
        {
            try
            {
                var licitacija = _licitacija.GetLicitacija(id);

                if (licitacija == null)
                {
                    return NotFound();
                }

                _licitacija.DeleteLicitacija(id);
                _licitacija.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("LicitacijaBasic/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicitacijaBasicInfoDto> GetLicitacijaBasic(Guid id)
        {
            try
            {
                var licitacijaBasic = _licitacija.GetLicitacijaBasic(id);

                if (licitacijaBasic == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<LicitacijaBasicInfoDto>(licitacijaBasic);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

    }
}
