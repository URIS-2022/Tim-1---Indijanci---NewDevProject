using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.ObradivostDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ParcelaAPI.Controllers
{
    /// <summary>
    /// Obradivost kontroler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class ObradivostController : ControllerBase
    {
        private readonly IObradivostRepository _obradivostRepository;
        private readonly IMapper _mapper;

        public ObradivostController(IObradivostRepository obradivostRepository, IMapper mapper)
        {
            _obradivostRepository = obradivostRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve obradivosti
        /// </summary>
        /// <returns>Lista obradivosti</returns>
        /// <response code="200">Vraća listu obradivosti</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<ObradivostDto>> GetAllObradivosti()
        {
            try
            {
                var obradivosti = _obradivostRepository.GetAll();

                if (obradivosti == null || obradivosti.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<ObradivostDto>>(obradivosti));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu obradivost na osnovu ID-ja obradivosti.
        /// </summary>
        /// <param name="id">ID obradivosti</param>
        /// <returns>Jedna obradivost</returns>
        /// <response code="200">Vraća traženu obradivost</response>
        /// <response code="404">Nije pronađena nijedna obradivost sa datim ID obradivosti</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ObradivostDto> GetObradivost(Guid id)
        {
            try
            {
                var obradivost = _obradivostRepository.GetObradivost(id);

                if (obradivost == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ObradivostDto>(obradivost));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novu obradivost
        /// </summary>
        /// <param name="obradivostDTO">Model obradivost</param>
        /// <returns>Potvrda o kreiranoj obradivosti</returns>
        /// <response code="201">Vraća kreiranu obradivost</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ObradivostDto> CreateObradivost([FromBody] ObradivostCreateDto obradivostDTO)
        {
            try
            {
                Obradivost obradivost = _mapper.Map<Obradivost>(obradivostDTO);
                _obradivostRepository.InsertObradivost(obradivost);
                _obradivostRepository.Save();
                return Created("GetObradivost", _mapper.Map<ObradivostDto>(obradivost));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu obradivost
        /// </summary>
        /// <param name="obradivostDTO">Model obradivosti koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj obradivosti.</returns>
        /// <response code="200">Vraća ažuriranu obradivost</response>
        /// <response code="404">Obradivost koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ObradivostDto> UpdateObradivost([FromBody] ObradivostUpdateDto obradivostDTO)
        {
            try
            {
                var obradivostToUpdate = _obradivostRepository.GetObradivost(obradivostDTO.ObradivostId);

                if (obradivostToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(obradivostDTO, obradivostToUpdate);
                _obradivostRepository.Save();
                return Ok(_mapper.Map<ObradivostDto>(obradivostToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne obradivosti na osnovu ID-ja obradivosti
        /// </summary>
        /// <param name="id">ID obradivosti</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Obradivost uspešno obrisana</response>
        /// <response code="404">Nije pronađena obradivost za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteObradivost(Guid id)
        {
            try
            {
                var obradivost = _obradivostRepository.GetObradivost(id);

                if (obradivost == null)
                {
                    return NotFound();
                }

                _obradivostRepository.DeleteObradivost(id);
                _obradivostRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
