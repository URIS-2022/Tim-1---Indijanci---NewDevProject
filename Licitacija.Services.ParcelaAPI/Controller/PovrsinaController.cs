using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.DeoParceleDTOs;
using Licitacija.Services.ParcelaAPI.DTOs.PovrsinaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.ConcreteClasses;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ParcelaAPI.Controller
{
    /// <summary>
    /// Povrsina kontroler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class PovrsinaController : ControllerBase
    {
        private readonly IPovrsinaRepository _povrsinaRepository;
        private readonly IMapper _mapper;

        public PovrsinaController(IPovrsinaRepository povrsinaRepository, IMapper mapper)
        {
            _povrsinaRepository = povrsinaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve povrsine.
        /// </summary>
        /// <returns>Lista povrsina.</returns>
        /// <response code="200">Vraća listu povrsina.</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<PovrsinaDto>> GetAllPovrsine()
        {
            try
            {
                var povrsine = _povrsinaRepository.GetAll();

                if (povrsine == null || povrsine.Count == 0)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<PovrsinaDto>>(povrsine);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vrši pretragu jedne povrsine na osnovu ID-ja povrsine.
        /// </summary>
        /// <param name="id">ID povrsine</param>
        /// <returns>Jedna povrsina</returns>
        /// <response code="200">Vraća traženu povrsinu</response>
        /// <response code="404">Nije pronađena nijedna povrsina sa datim ID povrsine</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PovrsinaDto> GetPovrsina(Guid id)
        {
            try
            {
                var povrsina = _povrsinaRepository.GetPovrsina(id);

                if (povrsina == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<PovrsinaDto>(povrsina);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novu povrsinu.
        /// </summary>
        /// <param name="povrsinaDTO">Model povrsine</param>
        /// <returns>Potvrda o kreiranoj povrsini.</returns>
        /// <response code="201">Vraća kreiranu povrsinu</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PovrsinaDto> CreatePovrsina([FromBody] PovrsinaCreateDto povrsinaDTO)
        {
            try
            {
                Povrsina povrsina = _mapper.Map<Povrsina>(povrsinaDTO);
                _povrsinaRepository.InsertPovrsina(povrsina);
                _povrsinaRepository.Save();
                return Created("GetPovrsina", _mapper.Map<PovrsinaDto>(povrsina));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu povrsinu.
        /// </summary>
        /// <param name="povrsinaDTO">Model povrsine koja se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj povrsini</returns>
        /// <response code="200">Vraća ažuriranu povrsinu</response>
        /// <response code="404">Povrsina koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PovrsinaDto> UpdatePovrsina([FromBody] PovrsinaUpdateDto povrsinaDTO)
        {
            try
            {
                var povrsinaToUpdate = _povrsinaRepository.GetPovrsina(povrsinaDTO.PovrsinaId);

                if (povrsinaToUpdate == null)
                {
                    return NotFound();
                }


                _mapper.Map(povrsinaDTO, povrsinaToUpdate);
                _povrsinaRepository.Save();
                return Ok(_mapper.Map<PovrsinaDto>(povrsinaToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne povrsine na osnovu ID-ja povrsine.
        /// </summary>
        /// <param name = "id" > ID povrsine</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Povrsina uspešno obrisana</response>
        /// <response code="404">Nije pronađena povrsina za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeletePovrsina(Guid id)
        {
            try
            {
                var povrsina = _povrsinaRepository.GetPovrsina(id);

                if (povrsina == null)
                {
                    return NotFound();
                }

                _povrsinaRepository.DeletePovrsina(id);
                _povrsinaRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
