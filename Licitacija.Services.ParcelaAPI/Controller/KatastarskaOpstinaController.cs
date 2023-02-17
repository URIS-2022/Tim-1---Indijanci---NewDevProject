using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.KatastarskaOpstinaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using Microsoft.AspNetCore.Http;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;


namespace Licitacija.Services.ParcelaAPI.Controllers
{
    /// <summary>
    /// Katastarska opstina kontroler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class KatastarskaOpstinaController : ControllerBase
    {
        private readonly IKatastarskaOpstinaRepository _katastarskaOpstinaRepository;
        private readonly IMapper _mapper;

        public KatastarskaOpstinaController(IKatastarskaOpstinaRepository katastarskaOpstinaRepository, IMapper mapper)
        {
            _katastarskaOpstinaRepository = katastarskaOpstinaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve katastarske opstine
        /// </summary>
        /// <returns>Lista katastarskih opstina</returns>
        /// <response code="200">Vraća listu katastarskih opstina</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<KatastarskaOpstinaDto>> GetAllKatastarskeOpstine()
        {
            try
            {
                var katastarskeOpstine = _katastarskaOpstinaRepository.GetAll();

                if (katastarskeOpstine == null || katastarskeOpstine.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<KatastarskaOpstinaDto>>(katastarskeOpstine));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu katastarsku opstinu na osnovu ID-ja katastarske opstine
        /// </summary>
        /// <param name="id">ID katastarske opstine</param>
        /// <returns>Jedna katastarska opstina</returns>
        /// <response code="200">Vraća traženu katastarsku opstinu</response>
        /// <response code="404">Nije pronađena nijedna katastarska opstina sa datim ID zkatastarske opstine</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KatastarskaOpstinaDto> GetKatastarskaOpstina(Guid id)
        {
            try
            {
                var katastarskaOpstina = _katastarskaOpstinaRepository.GetKatastarskaOpstina(id);

                if (katastarskaOpstina == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstina));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu katastarsku opstinu na osnovu ID-ja katastarske opstine
        /// </summary>
        /// <param name="id">ID katastarske opstine</param>
        /// <returns>Jedna katastarska opstina</returns>
        /// <response code="200">Vraća traženu katastarsku opstinu</response>
        /// <response code="404">Nije pronađena nijedna katastarska opstina sa datim ID zkatastarske opstine</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("KatastarskaOpstinaBasicInfo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KatastarskaOpstinaBasicInfoDto> GetKatastarskaOpstinaBasicInfo(Guid id)
        {
            try
            {
                var katastarskaOpstinaBasicInfo = _katastarskaOpstinaRepository.GetKatastarskaOpstinaBasicInfo(id);

                if (katastarskaOpstinaBasicInfo == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<KatastarskaOpstinaBasicInfoDto>(katastarskaOpstinaBasicInfo);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira nova katastarska opstina
        /// </summary>
        /// <param name="katastarskaOpstinaDTO">Model katastarske opstine</param>
        /// <returns>Potvrda o kreiranoj katastarskoj opstini</returns>
        /// <response code="201">Vraća kreiranu katastarsku opstinu</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KatastarskaOpstinaDto> CreateKatastarskaOpstina([FromBody] KatastarskaOpstinaCreateDto katastarskaOpstinaDTO)
        {
            try
            {
                KatastarskaOpstina katastarskaOpstina = _mapper.Map<KatastarskaOpstina>(katastarskaOpstinaDTO);
                _katastarskaOpstinaRepository.InsertKatastarskaOpstina(katastarskaOpstina);
                _katastarskaOpstinaRepository.Save();
                return Created("GetKatastarskaOpstina", _mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstina));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu katastarsku opstinu
        /// </summary>
        /// <param name="katastarskaOpstinaDTO">Model katarske opstine koja se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj katastarskoj opstini</returns>
        /// <response code="200">Vraća ažuriranu katastarsku opstinu</response>
        /// <response code="404">Katastarska opstina koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KatastarskaOpstinaDto> UpdateKatastarskaOpstina([FromBody] KatastarskaOpstinaUpdateDto katastarskaOpstinaDTO)
        {
            try
            {
                var katastarskaOpstinaToUpdate = _katastarskaOpstinaRepository.GetKatastarskaOpstina(katastarskaOpstinaDTO.KatOpstinaId);

                if (katastarskaOpstinaToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(katastarskaOpstinaDTO, katastarskaOpstinaToUpdate);
                _katastarskaOpstinaRepository.Save();
                return Ok(_mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstinaToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne katastarske opstine na osnovu ID-ja katastarske opstine
        /// </summary>
        /// <param name="id">ID katastarske opstine</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Katastarske opstina uspešno obrisana</response>
        /// <response code="404">Nije pronađena katastarska opstina za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteKatastarskaOpstina(Guid id)
        {
            try
            {
                var katastarskaOpstina = _katastarskaOpstinaRepository.GetKatastarskaOpstina(id);

                if (katastarskaOpstina == null)
                {
                    return NotFound();
                }

                _katastarskaOpstinaRepository.DeleteKatastarskaOpstina(id);
                _katastarskaOpstinaRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
