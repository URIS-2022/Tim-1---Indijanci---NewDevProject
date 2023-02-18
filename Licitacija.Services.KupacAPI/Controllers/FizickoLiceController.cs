using AutoMapper;
using Licitacija.Services.KupacAPI.DTOs.FizickoLiceDTOs;
using Licitacija.Services.KupacAPI.DTOs.KontaktOsobaDTOs;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KupacAPI.Controllers
{
    [ApiController]
    [Route("api/fizickoLice")]
    [Produces("application/json", "application/xml")]
    public class FizickoLiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FizickoLiceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sva fizicka lica.
        /// </summary>
        /// <returns>Lista fizickih lica.</returns>
        /// <response code="200">Vraća listu fizickih lica</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet]   
        public async Task<IActionResult> GetFizickaLica()
        {
            try
            {
                var fLica = await _unitOfWork.FizickoLice.GetAll();

                if (fLica == null) return NoContent();

                var results = _mapper.Map<List<FizickoLiceDto>>(fLica);

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Vraća jedno fizicko lice na osnovu ID-ja fizickog lica.
        /// </summary>
        /// <param name="id">ID fizickog lica</param>
        /// <returns>Jedno fizicko lice.</returns>
        /// <response code="200">Vraća traženo fizicko lice</response>
        /// <response code="404">Nije pronađeno nijedno fizicko lice sa datim ID fizickog lica</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet("{id:guid}", Name = "GetFizickoLice")]
        public async Task<IActionResult> GetFizickoLice(Guid id)
        {
            try
            {
                var fLice = await _unitOfWork.FizickoLice.Get(i => i.FizickoLiceId == id);

                if (fLice == null) return NotFound();

                var result = _mapper.Map<FizickoLiceDto>(fLice);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Kreira novo fizicko lice.
        /// </summary>
        /// <param name="fLiceDTO">Model fizickog lica</param>
        /// <returns>Potvrda o kreiranom fizickom licu.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog fizickog lica \
        /// POST /api/fizickoLice \
        /// {     \
        ///     "kupacId":"8302A0FD-A699-4ED0-97EA-37AB4F618801" \
        ///     "fizickoLiceIme": "ImePrimer", \
        ///     "fizickoLicePrezime": "PrezimePrimer", \
        ///     "JMBG": "1234567890123" \
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreirano fizicko lice</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpPost]
        public async Task<IActionResult> CreateFizickoLice([FromBody] FizickoLiceCreateDto fLiceDTO)
        {
            try
            {
                var fLice = _mapper.Map<FizickoLice>(fLiceDTO);

                fLice.FizickoLiceId = Guid.NewGuid();

                await _unitOfWork.FizickoLice.Insert(fLice);

                await _unitOfWork.Save();

                return CreatedAtRoute("GetFizickoLice", new { id = fLice.FizickoLiceId }, fLice);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Insert error.");
            }
        }

        /// <summary>
        /// Ažurira jedno fizicko lice.
        /// </summary>
        /// <param name="fLiceDTO">Model fizickog lica koje se ažurira</param>
        /// <returns>Potvrdu o modifikovanom fizickom licu.</returns>
        /// <response code="200">Fizicko lice uspesno azurirano</response>
        /// <response code="404">Fizicko lice koje se ažurira nije pronađeno</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpPut]
        public async Task<IActionResult> UpdateFizickoLice([FromBody] FizickoLiceUpdateDto fLiceDTO)
        {

            try
            {
                var fLice = await _unitOfWork.FizickoLice.Get(i => i.FizickoLiceId == fLiceDTO.FizickoLiceId);

                if (fLice == null) return NotFound();

                _mapper.Map(fLiceDTO, fLice);

                _unitOfWork.FizickoLice.Update(fLice);

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
        /// Vrši brisanje jednog fizickog lica na osnovu ID-ja fizickog lica.
        /// </summary>
        /// <param name="id">ID fizickog lica</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Fizicko lice uspešno obrisano</response>
        /// <response code="404">Nije pronađeno fizicko lice za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFizickoLice(Guid id)
        {
            try
            {
                var fLice = await _unitOfWork.FizickoLice.Get(i => i.FizickoLiceId == id);

                if (fLice == null) return NotFound();

                await _unitOfWork.FizickoLice.Delete(id);

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
