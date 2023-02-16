using AutoMapper;
using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.NadmetanjeAPI.Models;
using Licitacija.Services.NadmetanjeAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.NadmetanjeAPI.Controllers
{
    /// <summary>
    /// Status nadmetanja controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class StatusNadmetanjaController : ControllerBase
    {
        private readonly IStatusNadmetanjaRepository _statusNadmetanjaRepository;
        private readonly IMapper _mapper;

        public StatusNadmetanjaController(IStatusNadmetanjaRepository statusNadmetanjaRepository, IMapper mapper)
        {
            _statusNadmetanjaRepository = statusNadmetanjaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve statuse nadmetanja.
        /// </summary>
        /// <returns>Lista statusa nadmetanja.</returns>
        /// <response code="200">Vraća listu statusa nadmetanja</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<StatusNadmetanjaDto>> GetAllStatuse()
        {
            try
            {
                var statusi = _statusNadmetanjaRepository.GetAll();

                if (statusi == null || statusi.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<StatusNadmetanjaDto>>(statusi));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vraća jedan status na osnovu ID-ja statusa.
        /// </summary>
        /// <param name="id">ID statusa</param>
        /// <returns>Jedan status.</returns>
        /// <response code="200">Vraća traženi status</response>
        /// <response code="404">Nije pronađen nijedan status sa datim ID statusa</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusNadmetanjaDto> GetStatusNadmetanja(Guid id)
        {
            try
            {
                var kurs = _statusNadmetanjaRepository.GetStatusNadmetanja(id);

                if (kurs == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<StatusNadmetanjaDto>(kurs));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novi status.
        /// </summary>
        /// <param name="statusNadmetanjaDto">Model statusa</param>
        /// <returns>Potvrda o kreiranom statusu.</returns>
        /// <response code="201">Vraća kreirani status</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusNadmetanjaDto> CreateStatusNadmetanja([FromBody] StatusNadmetanjaCreateDto statusNadmetanjaDto)
        {
            try
            {
                StatusNadmetanja status = _mapper.Map<StatusNadmetanja>(statusNadmetanjaDto);
                _statusNadmetanjaRepository.InsertStatusNadmetanja(status);
                _statusNadmetanjaRepository.Save();
                return Created("GetStatus", _mapper.Map<StatusNadmetanjaDto>(status));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan status.
        /// </summary>
        /// <param name="statusNadmetanjaDto">Model statusa koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom statusu.</returns>
        /// <response code="200">Vraća ažuriran status</response>
        /// <response code="404">Status koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusNadmetanjaDto> UpdateStatusNadmetanja([FromBody] StatusNadmetanjaUpdateDto statusNadmetanjaDto)
        {
            try
            {
                var statusToUpdate = _statusNadmetanjaRepository.GetStatusNadmetanja(statusNadmetanjaDto.StatusNadmetanjaId);

                if (statusToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(statusNadmetanjaDto, statusToUpdate);
                _statusNadmetanjaRepository.Save();
                return Ok(_mapper.Map<StatusNadmetanjaDto>(statusToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog statusa na osnovu ID-ja statusa.
        /// </summary>
        /// <param name="id">ID statusa</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Status uspešno obrisan</response>
        /// <response code="404">Nije pronađen status za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteStatusNadmetanja(Guid id)
        {
            try
            {
                var status = _statusNadmetanjaRepository.GetStatusNadmetanja(id);

                if (status == null)
                {
                    return NotFound();
                }

                _statusNadmetanjaRepository.DeleteStatusNadmetanja(id);
                _statusNadmetanjaRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
