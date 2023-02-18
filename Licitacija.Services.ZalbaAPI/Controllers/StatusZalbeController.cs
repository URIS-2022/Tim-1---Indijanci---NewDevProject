using AutoMapper;
using Licitacija.Services.ZalbaAPI.DTOs.StatusZalbeDTOs;
using Licitacija.Services.ZalbaAPI.Entities;
using Licitacija.Services.ZalbaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ZalbaAPI.Controllers
{
    /// <summary>
    /// StatusZalbe controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class StatusZalbeController : ControllerBase
    {
        private readonly IStatusZalbeRepository _statusZalbeRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// StatusZalbe controller.
        /// </summary>
        public StatusZalbeController(IStatusZalbeRepository statusZalbeRepository, IMapper mapper)
        {
            _statusZalbeRepository = statusZalbeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve statuse zalbi.
        /// </summary>
        /// <returns>Lista statusa zalbi.</returns>
        /// <response code="200">Vraća listu statusa zalbi</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<StatusZalbeDto>> GetAllStatusZalbe()
        {
            try
            {
                var statusZalbe = _statusZalbeRepository.GetAll();

                if (statusZalbe == null || statusZalbe.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<StatusZalbeDto>>(statusZalbe));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jedan status zalbe na osnovu ID-ja statusa zalbe.
        /// </summary>
        /// <param name="id">ID statusa zalbe</param>
        /// <returns>Jedan status zalbe.</returns>
        /// <response code="200">Vraća traženi status zalbe</response>
        /// <response code="404">Nije pronađen nijedan status zalbe sa datim ID statusom zalbe</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusZalbeDto> GetStatusZalbe(Guid id)
        {
            try
            {
                var statusZalbe = _statusZalbeRepository.GetStatusZalbe(id);

                if (statusZalbe == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<StatusZalbeDto>(statusZalbe));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novi status zalbe.
        /// </summary>
        /// <param name="statusZalbeDto">Model statusa zalbe</param>
        /// <returns>Potvrda o kreiranom statusu zalbe.</returns>
        /// <response code="201">Vraća kreirani status zalbe</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusZalbeDto> CreateStatusZalbe([FromBody] StatusZalbeCreateDto statusZalbeDto)
        {
            try
            {
                StatusZalbe statusZalbe = _mapper.Map<StatusZalbe>(statusZalbeDto);
                _statusZalbeRepository.InsertStatusZalbe(statusZalbe);
                _statusZalbeRepository.Save();
                return Created("GetStatusZalbe", _mapper.Map<StatusZalbeDto>(statusZalbe));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan status zalbe.
        /// </summary>
        /// <param name="statusZalbeDto">Model statusa zalbe koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom statusu zalbe.</returns>
        /// <response code="200">Vraća ažuriran status zalbe</response>
        /// <response code="404">Status zalbe koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusZalbeDto> UpdateStatusZalbe([FromBody] StatusZalbeUpdateDto statusZalbeDto)
        {
            try
            {
                var statusZalbeToUpdate = _statusZalbeRepository.GetStatusZalbe(statusZalbeDto.StatusZalbeId);

                if (statusZalbeToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(statusZalbeDto, statusZalbeToUpdate);
                _statusZalbeRepository.Save();
                return Ok(_mapper.Map<StatusZalbeDto>(statusZalbeToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog statusa zalbe na osnovu ID-ja statusa zalbe.
        /// </summary>
        /// <param name="id">ID statusa zalbe</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Status zalbe uspešno obrisan</response>
        /// <response code="404">Nije pronađen status zalbe za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteStatusZalbe(Guid id)
        {
            try
            {
                var statusZalbe = _statusZalbeRepository.GetStatusZalbe(id);

                if (statusZalbe == null)
                {
                    return NotFound();
                }

                _statusZalbeRepository.DeleteStatusZalbe(id);
                _statusZalbeRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
