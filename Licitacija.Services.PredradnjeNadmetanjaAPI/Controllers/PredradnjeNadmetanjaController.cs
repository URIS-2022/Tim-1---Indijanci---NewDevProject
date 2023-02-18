using AutoMapper;
using Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs;
using Licitacija.Services.PredradnjeNadmetanjaAPI.Entities;
using Licitacija.Services.PredradnjeNadmetanjaAPI.Repositories.Interfaces;
using Licitacija.Services.PredradnjeNadmetanjaAPI.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Controllers
{
    [Route("api/predradnjeNadmetanja")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class PredradnjeNadmetanjaController : Controller
    {
        private readonly IPredradnjeNadmetanjaRepository _predradnjeNadmetanja;
        private readonly ILicitacijaService _licitacijaService;
        private readonly IMapper _mapper;

        public PredradnjeNadmetanjaController(IPredradnjeNadmetanjaRepository predradnjeNadmetanja, IMapper mapper, ILicitacijaService licitacijaService)  
        {
            _predradnjeNadmetanja = predradnjeNadmetanja;
            _licitacijaService = licitacijaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve predradnje nadmetanja.
        /// </summary>
        /// <returns>Lista predradnji nadmetanja.</returns>
        /// <response code="200">Vraća listu predradnji nadmetanja</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin")]
        [HttpGet]
        public async Task<IActionResult> GetPredradnjeNadmetanja()
        {
            try
            {
                var predradnje = await _predradnjeNadmetanja.GetAll();

                if (predradnje == null) return NoContent();

                var results = _mapper.Map<List<PredradnjeNadmetanjaDto>>(predradnje);

                foreach (var result in results)
                {
                    FazaDto faza = _licitacijaService.GetFazaById((Guid)result.FazaId).Result;
                    result.Faza = faza;
                }

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Vraća jednu predradnju nadmetanja na osnovu ID-ja predradnje nadmetanja.
        /// </summary>
        /// <param name="id">ID predradnje nadmetanja</param>
        /// <returns>Jedna predradnja nadmetanja.</returns>
        /// <response code="200">Vraća traženu predradnju nadmetanja</response>
        /// <response code="404">Nije pronađena nijedna predradnja nadmetanja sa datim ID predradnje nadmetanja</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "SuperUser, Menadzer, Admin")]
        [HttpGet("{id:guid}", Name = "GetPredradnjaNadmetanja")]
        public async Task<IActionResult> GetPredradnjaNadmetanja(Guid id)
        {
            try
            {
                var predradnja = await _predradnjeNadmetanja.Get(i => i.PredradnjeNadmetanjaId == id);

                if (predradnja == null) return NotFound();

                var result = _mapper.Map<PredradnjeNadmetanjaDto>(predradnja);

                FazaDto faza = _licitacijaService.GetFazaById((Guid)result.FazaId).Result;

                result.Faza = faza;

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Kreira novu predradnju nadmetanja.
        /// </summary>
        /// <param name="predradnjeDTO">Model predradnje nadmetanja</param>
        /// <returns>Potvrda o kreiranoj predradnji nadmetanja.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove predradnje nadmetanja \
        /// POST /api/predradnjeNadmetanja \
        /// {     \
        ///     "predradnjeNadmetanjaNaziv": "Naziv primer" \
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreiranu predradnju nadmetanja</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles= "PrvaKomisija, Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePredradnjaNadmetanja([FromBody] PredradnjeNadmetanjaCreateDto predradnjeDTO)
        {
            try
            {
                var predradnja = _mapper.Map<PredradnjeNadmetanja>(predradnjeDTO);

                predradnja.PredradnjeNadmetanjaId = Guid.NewGuid();

                await _predradnjeNadmetanja.Insert(predradnja);

                await _predradnjeNadmetanja.Save();

                return CreatedAtRoute("GetPredradnjaNadmetanja", new { id = predradnja.PredradnjeNadmetanjaId }, predradnja);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Insert error.");
            }
        }

        /// <summary>
        /// Ažurira jednu predradnju nadmetanja.
        /// </summary>
        /// <param name="predradnjeDTO">Model predradnje nadmetanja koja se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj predradnji namdetanja.</returns>
        /// <response code="200">Vraća ažuriranu predradnju nadmetanja</response>
        /// <response code="404">Predradnja nadmetanja koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "PrvaKomisija, Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdatePredradnjaNadmetanja([FromBody] PredradnjeNadmetanjaUpdateDto predradnjeDTO)
        {
            try
            {
                var predradnja = await _predradnjeNadmetanja.Get(i => i.PredradnjeNadmetanjaId == predradnjeDTO.PredradnjeNadmetanjaId);

                if (predradnja == null) return NotFound();

                _mapper.Map(predradnjeDTO, predradnja);//mapira dto koji ima izmenjene info na entitet drzave

                _predradnjeNadmetanja.Update(predradnja);

                await _predradnjeNadmetanja.Save();

                return Ok();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Update error.");
            }
        }

        /// <summary>
        /// Vrši brisanje jedne predradnje nadmetanja na osnovu ID-ja predradnje nadmetanja.
        /// </summary>
        /// <param name="id">ID predradnje nadmetanja</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Predradnja nadmetanja uspešno obrisana</response>
        /// <response code="404">Nije pronađena predradnja nadmetanja za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "PrvaKomisija, Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePredradnjaNadmetanja(Guid id)
        {
            try
            {
                var predradnja = await _predradnjeNadmetanja.Get(i => i.PredradnjeNadmetanjaId == id);

                if (predradnja == null) return NotFound();

                await _predradnjeNadmetanja.Delete(id);

                await _predradnjeNadmetanja.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Delete error.");
            }
        }

        /// <summary>
        /// Vraća jednu predradnju nadmetanja sa osnovnim info na osnovu ID-ja predradnje nadmetanja.
        /// </summary>
        /// <param name="id">ID predradnje nadmetanja</param>
        /// <returns>Jedna predradnja nadmetanja sa osnovnim info.</returns>
        /// <response code="200">Vraća traženu predradnju nadmetanja sa osnovnim info</response>
        /// <response code="404">Nije pronađena nijedna predradnja nadmetanja sa datim ID predradnje nadmetanja</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "SuperUser, Menadzer, Admin")]
        [HttpGet("predradnjaOsnovneInfo/{id:guid}")]
        public async Task<IActionResult> GetPredradnjaBasicInfo(Guid id)
        {
            try
            {
                var predradnja = await _predradnjeNadmetanja.GetPredradnjeBasicInfo(id);

                if (predradnja == null) return NotFound();

                var result = _mapper.Map<PredradnjeBasicInfoDto>(predradnja);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

    }
}
