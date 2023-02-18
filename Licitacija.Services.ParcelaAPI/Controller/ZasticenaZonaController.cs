using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.ZasticenaZonaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ParcelaAPI.Controllers
{
    /// <summary>
    /// Zasticena zona kontroler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class ZasticenaZonaController : ControllerBase
    {
        private readonly IZasticenaZonaRepository _zasticenaZonaRepository;
        private readonly IMapper _mapper;

        public ZasticenaZonaController(IZasticenaZonaRepository zasticenaZonaRepository, IMapper mapper)
        {
            _zasticenaZonaRepository = zasticenaZonaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve zasticene zone
        /// </summary>
        /// <returns>Lista zasticene zone</returns>
        /// <response code="200">Vraća listu zasticenih zona</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<ZasticenaZonaDto>> GetAllZasticeneZone()
        {
            try
            {
                var zasticeneZone = _zasticenaZonaRepository.GetAll();

                if (zasticeneZone == null || zasticeneZone.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<ZasticenaZonaDto>>(zasticeneZone));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu zasticenu zonu na osnovu ID-ja zasticene zone
        /// </summary>
        /// <param name="id">ID zasticene zone</param>
        /// <returns>Jedna zasticena zona</returns>
        /// <response code="200">Vraća traženu zasticenu zonu</response>
        /// <response code="404">Nije pronađena nijedna zasticena zona sa datim ID zasticene zone</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZasticenaZonaDto> GetZasticenaZona(Guid id)
        {
            try
            {
                var zasticenaZona = _zasticenaZonaRepository.GetZasticenaZona(id);

                if (zasticenaZona == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ZasticenaZonaDto>(zasticenaZona));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira nova zasticena zona
        /// </summary>
        /// <param name="zasticenaZonaDTO">Model zasticene zone</param>
        /// <returns>Potvrda o kreiranoj zasticenoj zoni</returns>
        /// <response code="201">Vraća kreiranu zasticenu zonu</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZasticenaZonaDto> CreateZasticenaZona([FromBody] ZasticenaZonaCreateDto zasticenaZonaDTO)
        {
            try
            {
                ZasticenaZona zasticenaZona = _mapper.Map<ZasticenaZona>(zasticenaZonaDTO);
                _zasticenaZonaRepository.InsertZasticenaZona(zasticenaZona);
                _zasticenaZonaRepository.Save();
                return Created("GetZasticenaZona", _mapper.Map<ZasticenaZonaDto>(zasticenaZona));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu zasticenu zonu
        /// </summary>
        /// <param name="zasticenaZonaDTO">Model zasticene zona koja se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj zasticenoj zoni</returns>
        /// <response code="200">Vraća ažuriranu zasticenu zonu</response>
        /// <response code="404">Zasticena zona koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZasticenaZonaDto> UpdateZasticenaZona([FromBody] ZasticenaZonaUpdateDto zasticenaZonaDTO)
        {
            try
            {
                var zasticenaZonaToUpdate = _zasticenaZonaRepository.GetZasticenaZona(zasticenaZonaDTO.ZZonaId);

                if (zasticenaZonaToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(zasticenaZonaDTO, zasticenaZonaToUpdate);
                _zasticenaZonaRepository.Save();
                return Ok(_mapper.Map<ZasticenaZonaDto>(zasticenaZonaToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne zasticene zone na osnovu ID-ja zasticene zone
        /// </summary>
        /// <param name="id">ID zasticene zone</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Zasticena zona uspešno obrisana</response>
        /// <response code="404">Nije pronađena zasticena zona za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteZasticenaZona(Guid id)
        {
            try
            {
                var zasticenaZona = _zasticenaZonaRepository.GetZasticenaZona(id);

                if (zasticenaZona == null)
                {
                    return NotFound();
                }

                _zasticenaZonaRepository.DeleteZasticenaZona(id);
                _zasticenaZonaRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
