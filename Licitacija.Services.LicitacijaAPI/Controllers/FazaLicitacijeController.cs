using AutoMapper;
using Licitacija.Services.LicitacijaAPI.Entities;
using Licitacija.Services.LicitacijaAPI.DTOs;
using Licitacija.Services.LicitacijaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Licitacija.Services.LicitacijaAPI.Repositories.Interface;
using Licitacija.Services.LicitacijaAPI.DTOs.FazaLicitacijeDTOs;
using Licitacija.Services.LicitacijaAPI.DTOs.LicitacijaDTOs;
using Licitacija.Services.LicitacijaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.LicitacijaAPI.Controllers
{
    /// <summary>
    /// Faza licitacije controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class FazaLicitacijeController : ControllerBase
    {
        private readonly IFazaLicitacije _fazaLicitacije;
        private readonly IMapper _mapper;

        /// <summary>
        /// Faza licitacije controller.
        /// </summary>
        public FazaLicitacijeController(IFazaLicitacije fazaLicitacije, IMapper mapper)
        {
            _fazaLicitacije = fazaLicitacije;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve faze licitacije.
        /// </summary>
        /// <returns>Lista faze licitacije.</returns>
        /// <response code="200">Vraća listu faza licitacije</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<FazaLicitacijeDto>> GetAllFazeLicitacije()
        {
            try
            {
                var fazeLicitacije = _fazaLicitacije.GetAll();

                if (fazeLicitacije == null || fazeLicitacije.Count == 0)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<FazaLicitacijeDto>>(fazeLicitacije);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu fazu licitacije na osnovu ID-ja faze licitacije.
        /// </summary>
        /// <param name="id">ID faze licitacije</param>
        /// <returns>Jedna faza licitacije.</returns>
        /// <response code="200">Vraća traženu fazu licitacije</response>
        /// <response code="404">Nije pronađena nijedna faza licitacije sa datim ID faze licitacije</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FazaLicitacijeDto> GetFazaLicitacije(Guid id)
        {
            try
            {
                var fazaLicitacije = _fazaLicitacije.GetFazaLicitacije(id);

                if (fazaLicitacije == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<FazaLicitacijeDto>(fazaLicitacije));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novu fazu licitacije.
        /// </summary>
        /// <param name="fazaLicitacijeDTO">Model faze licitacije</param>
        /// <returns>Potvrda o kreiranoj fazi licitacije.</returns>
        /// <response code="201">Vraća kreiranu fazu licitacije</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FazaLicitacijeDto> CreateFazaLicitacije([FromBody] FazaLicitacijeCreateDto fazaLicitacijeDTO)
        {
            try
            {
                FazaLicitacije fazalicitacije = _mapper.Map<FazaLicitacije>(fazaLicitacijeDTO);
                _fazaLicitacije.InsertFazaLicitacije(fazalicitacije);
                _fazaLicitacije.Save();
                return Created("GetFazaLicitacije", _mapper.Map<FazaLicitacijeDto>(fazalicitacije));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu fazu licitacije .
        /// </summary>
        /// <param name="fazaLicitacijeDTO">Model faze licitacije koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj fazi licitacije.</returns>
        /// <response code="200">Vraća ažuriranu fazu licitacije</response>
        /// <response code="404">Faza licitacije koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FazaLicitacijeDto> UpdateFazaLicitacije([FromBody] FazaLicitacijeUpdateDto fazaLicitacijeDTO)
        {
            try
            {
                var fazaLicitacijeToUpdate = _fazaLicitacije.GetFazaLicitacije(fazaLicitacijeDTO.FazaId);

                if (fazaLicitacijeToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(fazaLicitacijeDTO, fazaLicitacijeToUpdate);
                _fazaLicitacije.Save();
                return Ok(_mapper.Map<FazaLicitacijeDto>(fazaLicitacijeToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne faze licitacije na osnovu ID-ja faze licitacije.
        /// </summary>
        /// <param name="id">ID faze licitacije</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Faza licitacije uspešno obrisana</response>
        /// <response code="404">Nije pronađena faza licitacije za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteFazaLicitacije(Guid id)
        {
            try
            {
                var fazaLicitacije = _fazaLicitacije.GetFazaLicitacije(id);

                if (fazaLicitacije == null)
                {
                    return NotFound();
                }

                _fazaLicitacije.DeleteFazaLicitacije(id);
                _fazaLicitacije.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("FazaLicitacijeBasic/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FazaLicitacijeBasicInfoDto> GetFazaLicitacijeBasic(Guid id)
        {
            try
            {
                var fazaLicitacijeBasic = _fazaLicitacije.GetFazaLicitacijeBasic(id);

                if (fazaLicitacijeBasic == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<FazaLicitacijeBasicInfoDto>(fazaLicitacijeBasic);
                
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


    }
}
