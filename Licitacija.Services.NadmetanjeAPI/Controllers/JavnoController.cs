using AutoMapper;
using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.NadmetanjeAPI.Models;
using Licitacija.Services.NadmetanjeAPI.Repositories;
using Licitacija.Services.NadmetanjeAPI.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.NadmetanjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class JavnoController : ControllerBase
    {
        private readonly IJavnoRepository _javnoRepository;
        private readonly IEtapaService _etapaService;
        private readonly IMapper _mapper;

        public JavnoController(IJavnoRepository javnoRepository, IEtapaService etapaService, IMapper mapper)
        {
            _javnoRepository = javnoRepository;
            _etapaService = etapaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sva javna nadmetanja.
        /// </summary>
        /// <returns>Lista javnih nadmetanja.</returns>
        /// <response code="200">Vraća listu javnih nadmetanja</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<JavnoDto>> GetAllJavno()
        {
            try
            {
                var javno = _javnoRepository.GetAll();

                if (javno == null || javno.Count == 0)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<JavnoDto>>(javno);

                foreach(var javnoNadmetanje in result)
                {
                    EtapaDto etapa = _etapaService.GetEtapaById(javnoNadmetanje.EtapaId).Result;
                    javnoNadmetanje.Etapa = etapa;
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vraća jedno javno nadmetanje na osnovu ID-ja javnog nadmetanja.
        /// </summary>
        /// <param name="id">ID javnog nadmetanja</param>
        /// <returns>Jedno javno nadmetanje.</returns>
        /// <response code="200">Vraća traženo javno nadmetanje</response>
        /// <response code="404">Nije pronađeno nijedno javno nadmetanje sa datim ID javnog nadmetanja</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<JavnoDto> GetJavno(Guid id)
        {
            try
            {
                var javno = _javnoRepository.GetJavno(id);

                if (javno == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<JavnoDto>(javno);

                EtapaDto etapa = _etapaService.GetEtapaById(result.EtapaId).Result;
                result.Etapa = etapa;

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Kreira novo javno nadmetanje.
        /// </summary>
        /// <param name="javnoDto">Model javnog nadmetanja</param>
        /// <returns>Potvrda o kreiranom javnom nadmetanju.</returns>
        /// <response code="201">Vraća kreirano javno nadmetanje</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<JavnoDto> CreateJavno([FromBody] JavnoCreateDto javnoDto)
        {
            try
            {
                Javno javno = _mapper.Map<Javno>(javnoDto);
                _javnoRepository.InsertJavno(javno);
                _javnoRepository.Save();
                return Created("GetJavno", _mapper.Map<JavnoDto>(javno));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedno javno nadmetanje.
        /// </summary>
        /// <param name="javnoDto">Model javnog nadmetanja koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom javnom nadmetanju.</returns>
        /// <response code="200">Vraća ažurirano javno nadmetanje</response>
        /// <response code="404">Javno nadmetanje koje se ažurira nije pronađeno</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<JavnoDto> UpdateJavno([FromBody] JavnoUpdateDto javnoDto)
        {
            try
            {
                var javnoToUpdate = _javnoRepository.GetJavno(javnoDto.JavnoNadmetanjeId);

                if (javnoToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(javnoDto, javnoToUpdate);
                _javnoRepository.Save();
                return Ok(_mapper.Map<JavnoDto>(javnoToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog javnog nadmetanja na osnovu ID-ja javnog nadmetanja.
        /// </summary>
        /// <param name="id">ID javnog nadmetanja</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Javno nadmetanje uspešno obrisano</response>
        /// <response code="404">Nije pronađeno javno nadmetanje za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteJavno(Guid id)
        {
            try
            {
                var javno = _javnoRepository.GetJavno(id);

                if (javno == null)
                {
                    return NotFound();
                }

                _javnoRepository.DeleteJavno(id);
                _javnoRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
