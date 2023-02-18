using AutoMapper;
using Licitacija.Services.PredradnjeNadmetanjaAPI.ServiceCalls;
using Licitacija.Services.ProgramLicitacijeAPI.Entities;
using Licitacija.Services.ProgramLicitacijeAPI.Models.ExchangeDtos;
using Licitacija.Services.ProgramLicitacijeAPI.Models.KreiranjeProgramaLicitacijeDtos;
using Licitacija.Services.ProgramLicitacijeAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ProgramLicitacijeAPI.Controllers
{
    /// <summary>
    /// Program licitacije kontroler.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class KreiranjeProgramaLicitacijeController : ControllerBase
    {
        private readonly IKreiranjeProgramaLicitacijeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILicitacijaService _licitacijaService;

        /// <summary>
        /// Program licitacije kontroler.
        /// </summary>
        public KreiranjeProgramaLicitacijeController(IKreiranjeProgramaLicitacijeRepository repository, IMapper mapper,
            ILicitacijaService licitacijaService)
        {
            _repository = repository;
            _mapper = mapper;
            _licitacijaService = licitacijaService;
        }

        /// <summary>
        /// Vraća sve programe licitacije.
        /// </summary>
        /// <returns>Lista programa licitacije.</returns>
        /// <response code="200">Vraća listu programa licitacije</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetKreiranjeProgramaLicitacijeDto>>> GetAllProgramiLicitacije()
        {
            try
            {
                var programi = await _repository.GetAllProgramiLicitacije();

                if (programi.Count > 0)
                {
                    var results = _mapper.Map<List<GetKreiranjeProgramaLicitacijeDto>>(programi);

                    foreach (var result in results)
                    {
                        FazaDto? fazaLicitacije = await _licitacijaService.GetFazaById(result.FazaLicitacijeId);
                        result.FazaLicitacije = fazaLicitacije;
                    }

                    return Ok(results);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        /// <summary>
        /// Vraća program licitacije po id.
        /// </summary>
        /// <returns>Program licitacije.</returns>
        /// <response code="200">Vraća program licitacije po id</response>
        /// <response code="404">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetKreiranjeProgramaLicitacijeDto>> GetKreiranjeProgramaLicitacijeById([FromRoute] Guid id)
        {
            try
            {
                var program = await _repository.GetKreiranjeProgramaLicitacijeById(id);

                if (program != null)
                {
                    var result = _mapper.Map<GetKreiranjeProgramaLicitacijeDto>(program);
                    FazaDto? fazaLicitacije = await _licitacijaService.GetFazaById(result.ProgramId);
                    result.FazaLicitacije = fazaLicitacije;
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Kreira novi program licitacije.
        /// </summary>
        /// <param name="AddProgramLicitacijeDto">Model programa licitacije</param>
        /// <returns>Potvrda o kreiranom programu licitacije.</returns>
        /// <response code="201">Vraća kreirani program licitacije</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NoviProgramLicitacijeDto>> AddKreiranjeProgramaLicitacije([FromBody] AddProgramLicitacijeDto addProgramLicitacije)
        {
            try
            {
                var program = _repository.AddKreiranjeProgramaLicitacije(addProgramLicitacije);
                await _repository.Save();

                return Created("api/kreiranjeProgramaLicitacije", _mapper.Map<NoviProgramLicitacijeDto>(program));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan program licitacije.
        /// </summary>
        /// <param name="UpdateProgramLicitacijeDto">Model prograa licitacije koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom programu licitacije.</returns>
        /// <response code="200">Vraća ažuriran program licitacije</response>
        /// <response code="404">Program licitacije koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateProgramLicitacijeDto>> UpdateKreiranjeProgramaLicitacije([FromBody] UpdateProgramLicitacijeDto updateProgramLicitacije)
        {
            try
            {
                var program = await _repository.UpdateKreiranjeProgramaLicitacije(updateProgramLicitacije);

                if (program == null)
                {
                    return NotFound();
                }

                var toReturn = _mapper.Map(program, updateProgramLicitacije);

                await _repository.Save();

                return Ok(toReturn);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog programa licitacije po id.
        /// </summary>
        /// <param name="id">ID programa licitacije</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Program licitacije uspešno obrisan</response>
        /// <response code="404">Nije pronađen program licitacije za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKreiranjeProgramaLicitacije(Guid id)
        {
            try
            {
                bool isDeleted = await _repository.DeleteKreiranjeProgramaLicitacijeById(id);

                if (!isDeleted)
                {
                    return NotFound();
                }

                await _repository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Vraća program licitacije po id za komisiju.
        /// </summary>
        /// <returns>Program licitacije.</returns>
        /// <response code="200">Vraća program licitacije po id za komisiju</response>
        /// <response code="404">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("programZaKomisiju/{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<KreiranjeProgramaLicitacije>> GetKreiranjeProgramaLicitacijeZaKomisiju([FromRoute] Guid id)
        {
            try
            {
                var program = await _repository.GetKreiranjeProgramaLicitacijeById(id);

                if (program != null)
                {
                    return Ok(program);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
