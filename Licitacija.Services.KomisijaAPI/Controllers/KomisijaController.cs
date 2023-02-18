using AutoMapper;
using Licitacija.Services.KomisijaAPI.Models.ExchangeDtos;
using Licitacija.Services.KomisijaAPI.Models.KomisijaDtos;
using Licitacija.Services.KomisijaAPI.Repositories.Interfaces;
using Licitacija.Services.KomisijaAPI.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KomisijaAPI.Controllers
{
    /// <summary>
    /// Komisija kontroler.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class KomisijaController : ControllerBase
    {
        private readonly IKomisijaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IKreiranjeProgramaService _kreiranjeProgramaService;
        private readonly IPredradnjaNadmetanjaService _predradnjaNadmetanjaService;

        /// <summary>
        /// Komisija kontroler.
        /// </summary>
        public KomisijaController(IKomisijaRepository repository, IMapper mapper,
            IKreiranjeProgramaService kreiranjeProgramaService, IPredradnjaNadmetanjaService predradnjaNadmetanjaService)
        {
            _repository = repository;
            _mapper = mapper;
            _kreiranjeProgramaService = kreiranjeProgramaService;
            _predradnjaNadmetanjaService = predradnjaNadmetanjaService;
        }

        /// <summary>
        /// Vraća sve komisije.
        /// </summary>
        /// <returns>Lista komisija.</returns>
        /// <response code="200">Vraća listu komisija</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetKomisijaDto>>> GetKomisije()
        {
            try
            {
                var komisije = await _repository.GetAllKomisije();

                if (komisije.Count > 0)
                {
                    var results = _mapper.Map<List<GetKomisijaDto>>(komisije);

                    foreach (var result in results)
                    {
                        PredradnjaNadmetanjaDto? predradnjaNadmetanja = await _predradnjaNadmetanjaService.GetPredradnjaNadmetanja(result.PredradnjaNadmetanjaId);
                        ProgramDto? program = await _kreiranjeProgramaService.GetProgram(result.ProgramId);
                        result.PredradnjaNadmetanja = predradnjaNadmetanja;
                        result.Program = program;
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
        /// Vraća komisiju po id.
        /// </summary>
        /// <returns>Komisija.</returns>
        /// <response code="200">Vraća komisiju po id</response>
        /// <response code="404">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetKomisijaDto>> GetKomisija([FromRoute] Guid id)
        {
            try
            {
                var komisija = await _repository.GetKomisijaById(id);

                if (komisija != null)
                {
                    var result = _mapper.Map<GetKomisijaDto>(komisija);
                    PredradnjaNadmetanjaDto? predradnjaNadmetanja = await _predradnjaNadmetanjaService.GetPredradnjaNadmetanja(result.PredradnjaNadmetanjaId);
                    ProgramDto? program = await _kreiranjeProgramaService.GetProgram(result.ProgramId);
                    result.PredradnjaNadmetanja = predradnjaNadmetanja;
                    result.Program = program;
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
        /// Kreira novu komisiju.
        /// </summary>
        /// <param name="AddKomisijaDto">Model komisije</param>
        /// <returns>Potvrda o kreiranoj komisiji.</returns>
        /// <response code="201">Vraća kreiranu komisiju</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NovaKomisijaDto>> AddNovuKomisiju([FromBody]AddKomisijaDto addKomisija)
        {
            try
            {
                var komisija = _repository.AddKomisija(addKomisija);
                await _repository.Save();

                return Created("api/komisija", _mapper.Map<NovaKomisijaDto>(komisija));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu komisiju.
        /// </summary>
        /// <param name="UpdateKomisijaDto">Model komisije koja se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj komisiji.</returns>
        /// <response code="200">Vraća ažuriranu komisiju</response>
        /// <response code="404">Komisija koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateKomisijaDto>> UpdateKomisiju([FromBody] UpdateKomisijaDto updateKomisija)
        {
            try
            {
                var komisija = await _repository.UpdateKomisija(updateKomisija);

                if (komisija == null)
                {
                    return NotFound();
                }

                var toReturn = _mapper.Map(komisija, updateKomisija);

                await _repository.Save();

                return Ok(toReturn);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne komisije po id.
        /// </summary>
        /// <param name="id">ID komisije</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Komisija uspešno obrisana</response>
        /// <response code="404">Nije pronađena komisija za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKomisiju(Guid id)
        {
            try
            {
                bool isDeleted = await _repository.DeleteKomisijaById(id);

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
    }
}
