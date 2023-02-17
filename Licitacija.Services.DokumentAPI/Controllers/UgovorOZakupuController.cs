using AutoMapper;
using Licitacija.Services.DokumentAPI.Models.ExchangeDtos;
using Licitacija.Services.DokumentAPI.Models.UgovorOZakupuDtos;
using Licitacija.Services.DokumentAPI.Repositories.Interfaces;
using Licitacija.Services.DokumentAPI.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.DokumentAPI.Controllers
{
    /// <summary>
    /// Dokument kontroler.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class UgovorOZakupuController : ControllerBase
    {
        private readonly IUgovorOZakupuRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILicnostService _licnostService;
        private readonly IUplataService _uplataService;

        /// <summary>
        /// Dokument kontroler kontroler.
        /// </summary>
        public UgovorOZakupuController(IUgovorOZakupuRepository repository, IMapper mapper, ILicnostService licnostService, IUplataService uplataService)
        {
            _repository = repository;
            _mapper = mapper;
            _licnostService = licnostService;
            _uplataService = uplataService;
        }

        /// <summary>
        /// Vraća sve ugovore o zakupu.
        /// </summary>
        /// <returns>Lista ugovora o zakupu.</returns>
        /// <response code="200">Vraća listu ugovora o zakupu</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetUgovorOZakupuDto>>> GetUgovoreOZakupu()
        {
            try
            {
                var ugovoriOZakupu = await _repository.GetAllUgovorOZakupu();

                if (ugovoriOZakupu.Count > 0)
                {
                    var results = _mapper.Map<List<GetUgovorOZakupuDto>>(ugovoriOZakupu);

                    foreach (var result in results)
                    {
                        UplataDto? uplata = await _uplataService.GetUplataZaUgovor(result.UplataId);
                        LicnostDto? licnost = await _licnostService.GetLicnostZaUgovor(result.LicnostId);
                        result.Uplata = uplata;
                        result.Licnost = licnost;
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
        /// Vraća ugovor o zakupu po id.
        /// </summary>
        /// <returns>Ugovor o zakupu.</returns>
        /// <response code="200">Vraća ugovor o zakupu po id</response>
        /// <response code="404">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetUgovorOZakupuDto>> GetUgovorOZakupu([FromRoute] Guid id)
        {
            try
            {
                var ugovorOZakupu = await _repository.GetUgovorOZakupuById(id);

                if (ugovorOZakupu != null)
                {
                    var result = _mapper.Map<GetUgovorOZakupuDto>(ugovorOZakupu);
                    UplataDto? uplata = await _uplataService.GetUplataZaUgovor(result.UplataId);
                    LicnostDto? licnost = await _licnostService.GetLicnostZaUgovor(result.LicnostId);
                    result.Uplata = uplata;
                    result.Licnost = licnost;
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
        /// Kreira novi ugovor o zakupu.
        /// </summary>
        /// <param name="AddUgovorOZakupuDto">Model ugovora o zakupu</param>
        /// <returns>Potvrda o kreiranom ugovoru o zakupu.</returns>
        /// <response code="201">Vraća kreirani ugovor o zakupu</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NoviUgovorOZakupuDto>> AddNoviDokument([FromBody] AddUgovorOZakupuDto addUgovorOZakupu)
        {
            try
            {
                var ugovorOZakupu = _repository.AddUgovorOZakupu(addUgovorOZakupu);
                await _repository.Save();

                return Created("api/ugovorOZakupu", _mapper.Map<NoviUgovorOZakupuDto>(ugovorOZakupu));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan ugovor o zakupu.
        /// </summary>
        /// <param name="UpdateUgovorOZakupuDto">Model ugovora o zakupu koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom ugovoru o zakupu.</returns>
        /// <response code="200">Vraća ažuriran ugovor o zakupu</response>
        /// <response code="404">Ugovor o zakupu koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateUgovorOZakupuDto>> UpdateUgovorOZakupu([FromBody] UpdateUgovorOZakupuDto updateUgovorOZakupu)
        {
            try
            {
                var ugovorOZakupu = await _repository.UpdateUgovorOZakupu(updateUgovorOZakupu);

                if (ugovorOZakupu == null)
                {
                    return NotFound();
                }

                var toReturn = _mapper.Map(ugovorOZakupu, updateUgovorOZakupu);

                await _repository.Save();

                return Ok(toReturn);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog ugovora o zakupu po id.
        /// </summary>
        /// <param name="id">ID ugovora o zakupu</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Ugovor o zakupu uspešno obrisan</response>
        /// <response code="404">Nije pronađen ugovor o zakupu za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUgovorOZakupu(Guid id)
        {
            try
            {
                bool isDeleted = await _repository.DeleteUgovorOZakupuById(id);

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
