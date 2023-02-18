using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.OblikSvojineDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ParcelaAPI.Controllers
{
    /// <summary>
    /// Oblik svojine kontroler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class OblikSvojineController : ControllerBase
    {
        private readonly IOblikSvojineRepository _oblikSvojineRepository;
        private readonly IMapper _mapper;

        public OblikSvojineController(IOblikSvojineRepository oblikSvojineRepository, IMapper mapper)
        {
            _oblikSvojineRepository = oblikSvojineRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve oblike svojine
        /// </summary>
        /// <returns>Lista oblika svojine</returns>
        /// <response code="200">Vraća listu oblika svojine</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<OblikSvojineDto>> GetAllOblikaSvojine()
        {
            try
            {
                var obliciSvojine = _oblikSvojineRepository.GetAll();

                if (obliciSvojine == null || obliciSvojine.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<OblikSvojineDto>>(obliciSvojine));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jedan oblik svojine na osnovu ID-ja oblika svojine
        /// </summary>
        /// <param name="id">ID oblika svojine</param>
        /// <returns>Jedan oblik svojine</returns>
        /// <response code="200">Vraća tražen oblik svojine</response>
        /// <response code="404">Nije pronađen nijedan oblik svojine sa datim ID oblikom svojine</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OblikSvojineDto> GetOblikSvojine(Guid id)
        {
            try
            {
                var oblikSvojine = _oblikSvojineRepository.GetOblikSvojine(id);

                if (oblikSvojine == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<OblikSvojineDto>(oblikSvojine));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novi oblik svojine
        /// </summary>
        /// <param name="oblikSvojineDTO">Model oblika svojine</param>
        /// <returns>Potvrda o kreiranom obliku svojine.</returns>
        /// <response code="201">Vraća kreirani oblik svojine</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OblikSvojineDto> CreateOblikSvojine([FromBody] OblikSvojineCreateDto oblikSvojineDTO)
        {
            try
            {
                OblikSvojine oblikSvojine = _mapper.Map<OblikSvojine>(oblikSvojineDTO);
                _oblikSvojineRepository.InsertOblikSvojine(oblikSvojine);
                _oblikSvojineRepository.Save();
                return Created("GetOblikSvojine", _mapper.Map<OblikSvojineDto>(oblikSvojine));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan oblik svojine
        /// </summary>
        /// <param name="oblikSvojineDTO">Model oblika svojine koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom obliku svojine</returns>
        /// <response code="200">Vraća ažuriran oblik svojine</response>
        /// <response code="404">Oblik svojine koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OblikSvojineDto> UpdateOblikSvojine([FromBody] OblikSvojineUpdateDto oblikSvojineDTO)
        {
            try
            {
                var oblikSvojineToUpdate = _oblikSvojineRepository.GetOblikSvojine(oblikSvojineDTO.OblikSvojineId);

                if (oblikSvojineToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(oblikSvojineDTO, oblikSvojineToUpdate);
                _oblikSvojineRepository.Save();
                return Ok(_mapper.Map<OblikSvojineDto>(oblikSvojineToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog oblika svojine na osnovu ID-ja oblika svojine
        /// </summary>
        /// <param name="id">ID oblika svojine</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Oblik svojine uspešno obrisan</response>
        /// <response code="404">Nije pronađen oblik svojine za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteOblikSvojine(Guid id)
        {
            try
            {
                var oblikSvojine = _oblikSvojineRepository.GetOblikSvojine(id);

                if (oblikSvojine == null)
                {
                    return NotFound();
                }

                _oblikSvojineRepository.DeleteOblikSvojine(id);
                _oblikSvojineRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
