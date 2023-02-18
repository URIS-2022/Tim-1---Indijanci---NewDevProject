using AutoMapper;
using Licitacija.Services.KupacAPI.DTOs.FizickoLiceDTOs;
using Licitacija.Services.KupacAPI.DTOs.PravnoLiceDTOs;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KupacAPI.Controllers
{
    [ApiController]
    [Route("api/pravnoLice")]
    [Produces("application/json", "application/xml")]
    public class PravnoLiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPravnoLiceRepository _pravnoLiceRepository;
        private readonly IMapper _mapper;

        public PravnoLiceController(IUnitOfWork unitOfWork, IMapper mapper, IPravnoLiceRepository pravnoLiceRepository)
        {
            _unitOfWork = unitOfWork;
            _pravnoLiceRepository = pravnoLiceRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sva pravna lica.
        /// </summary>
        /// <returns>Lista pravnih lica.</returns>
        /// <response code="200">Vraća listu pravnih lica</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet]
        public async Task<IActionResult> GetPravnaLica()
        {
            try
            {
                var pLica = await _pravnoLiceRepository.GetAll();

                if (pLica == null) return NoContent();

                var results = _mapper.Map<List<PravnoLiceDto>>(pLica);

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Vraća jedno pravno lice na osnovu ID-ja pravnog lica.
        /// </summary>
        /// <param name="id">ID pravnog lica</param>
        /// <returns>Jedno pravno lice.</returns>
        /// <response code="200">Vraća traženo pravno lice</response>
        /// <response code="404">Nije pronađeno nijedno pravno lice sa datim ID pravnog lica</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet("{id:guid}", Name = "GetPravnoLice")]
        public async Task<IActionResult> GetPravnoLice(Guid id)
        {
            try
            {
                var pLice = await _pravnoLiceRepository.Get(id);

                if (pLice == null) return NotFound();

                var result = _mapper.Map<PravnoLiceDto>(pLice);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Kreira novo pravno lice.
        /// </summary>
        /// <param name="pLiceDTO">Model pravnog lica</param>
        /// <returns>Potvrda o kreiranom pravnom licu.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog pravnog lica \
        /// POST /api/pravnoLice \
        /// {     \
        ///     "kupacId":"8302A0FD-A699-4ED0-97EA-37AB4F618801" \
        ///     "pravnoLiceNaziv": "ImePrimer", \
        ///     "maticniBroj": "PrezimePrimer", \
        ///     "faks": "111-222-3333", \
        ///     "kontaktOsobaId: "9302A0FD-A699-4FD0-97EA-37AB4F618801"
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreirano pravno lice</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpPost]
        public async Task<IActionResult> CreatePravnoLice([FromBody] PravnoLiceCreateDto pLiceDTO)
        {
            try
            {
                var pLice = _mapper.Map<PravnoLice>(pLiceDTO);

                pLice.PravnoLiceId = Guid.NewGuid();

                await _unitOfWork.PravnoLice.Insert(pLice);

                await _unitOfWork.Save();

                return CreatedAtRoute("GetPravnoLice", new { id = pLice.PravnoLiceId }, pLice);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Insert error.");
            }
        }

        /// <summary>
        /// Ažurira jedno pravno lice.
        /// </summary>
        /// <param name="pLiceDTO">Model pravnog lica koje se ažurira</param>
        /// <returns>Potvrdu o modifikovanom pravnom licu.</returns>
        /// <response code="200">Pravno lice uspesno azurirano</response>
        /// <response code="404">Pravno lice koje se ažurira nije pronađeno</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpPut]
        public async Task<IActionResult> UpdatePravnoLice([FromBody] PravnoLiceUpdateDto pLiceDTO)
        {
            try
            {
                var pLice = await _unitOfWork.PravnoLice.Get(i => i.PravnoLiceId == pLiceDTO.PravnoLiceId);

                if (pLice == null) return NotFound();

                _mapper.Map(pLiceDTO, pLice);

                _unitOfWork.PravnoLice.Update(pLice);

                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Update error.");
            }
        }

        /// <summary>
        /// Vrši brisanje jednog pravnog lica na osnovu ID-ja pravnog lica.
        /// </summary>
        /// <param name="id">ID pravnog lica</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Pravno lice uspešno obrisano</response>
        /// <response code="404">Nije pronađeno pravno lice za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePravnoLice(Guid id)
        {
            try
            {
                var pLice = await _unitOfWork.PravnoLice.Get(i => i.PravnoLiceId == id);

                if (pLice == null) return NotFound();

                await _unitOfWork.PravnoLice.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Delete error.");
            }
        }
    }
}
