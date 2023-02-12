using AutoMapper;
using Licitacija.Services.UplataAPI.Entities;
using Licitacija.Services.UplataAPI.Models;
using Licitacija.Services.UplataAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.UplataAPI.Controllers
{
    /// <summary>
    /// Kurs controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class KursController : ControllerBase
    {
        private readonly IKursRepository _kursRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Kurs controller.
        /// </summary>
        public KursController(IKursRepository kursRepository, IMapper mapper)
        {
            _kursRepository = kursRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve kurseve.
        /// </summary>
        /// <returns>Lista kurseva.</returns>
        /// <response code="200">Vraća listu kurseva</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<KursDto>> GetAllKursevi()
        {
            try
            {
                var kursevi = _kursRepository.GetAll();

                if (kursevi == null || kursevi.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<KursDto>>(kursevi));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jedan kurs na osnovu ID-ja kursa.
        /// </summary>
        /// <param name="id">ID kursa</param>
        /// <returns>Jedan kurs.</returns>
        /// <response code="200">Vraća traženi kurs</response>
        /// <response code="404">Nije pronađen nijedan kurs sa datim ID kursa</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KursDto> GetKurs(Guid id)
        {
            try
            {
                var kurs = _kursRepository.GetKurs(id);

                if (kurs == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<KursDto>(kurs));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novi kurs.
        /// </summary>
        /// <param name="KursDto">Model kursa</param>
        /// <returns>Potvrda o kreiranom kursu.</returns>
        /// <response code="201">Vraća kreirani kurs</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KursDto> CreateKurs([FromBody] KursCreateDto KursDto)
        {
            try
            {
                Kurs kurs = _mapper.Map<Kurs>(KursDto);
                _kursRepository.InsertKurs(kurs);
                _kursRepository.Save();
                return Created("GetKurs", _mapper.Map<KursDto>(kurs));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan kurs.
        /// </summary>
        /// <param name="KursDto">Model kursa koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom kursu.</returns>
        /// <response code="200">Vraća ažuriran kurs</response>
        /// <response code="404">Kurs koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KursDto> UpdateKurs([FromBody] KursUpdateDto KursDto)
        {
            try
            {
                var kursToUpdate = _kursRepository.GetKurs(KursDto.KursId);

                if (kursToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(KursDto, kursToUpdate);
                _kursRepository.Save();
                return Ok(_mapper.Map<KursDto>(kursToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog kursa na osnovu ID-ja kursa.
        /// </summary>
        /// <param name="id">ID kursa</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Kurs uspešno obrisan</response>
        /// <response code="404">Nije pronađen kurs za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteKurs(Guid id)
        {
            try
            {
                var kurs = _kursRepository.GetKurs(id);

                if (kurs == null)
                {
                    return NotFound();
                }

                _kursRepository.DeleteKurs(id);
                _kursRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
