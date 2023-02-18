using AutoMapper;
using Licitacija.Services.KupacAPI.DTOs.KontaktOsobaDTOs;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KupacAPI.Controllers
{
    [ApiController]
    [Route("api/kontaktOsoba")]
    [Produces("application/json", "application/xml")]
    public class KontaktOsobaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public KontaktOsobaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve kontaks osobe.
        /// </summary>
        /// <returns>Lista kontakt osoba.</returns>
        /// <response code="200">Vraća listu kontakt osoba</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet]
        public async Task<IActionResult> GetKontaktOsobe()
        {
            try
            {
                var kOsobe = await _unitOfWork.KontaktOsoba.GetAll();

                if (kOsobe == null) return NoContent();

                var results = _mapper.Map<List<KontaktOsobaDto>>(kOsobe);

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Vraća jednu kontakt osobu na osnovu ID-ja kontakt osobe.
        /// </summary>
        /// <param name="id">ID kontakt osobe</param>
        /// <returns>Jedna kontakt osoba.</returns>
        /// <response code="200">Vraća traženu kontakt osobu</response>
        /// <response code="404">Nije pronađena nijedna kontakt osoba sa datim ID kontakt osobe</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet("{id:guid}", Name = "GetKontaktOsoba")]
        public async Task<IActionResult> GetKontaktOsoba(Guid id)
        {
            try
            {
                var kOsoba = await _unitOfWork.KontaktOsoba.Get(i => i.KontaktOsobaId == id);

                if (kOsoba == null) return NotFound();

                var result = _mapper.Map<KontaktOsobaDto>(kOsoba);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Kreira novu kontakt osobu.
        /// </summary>
        /// <param name="kOsobaDTO">Model kontakt osobe</param>
        /// <returns>Potvrda o kreiranoj kontakt osobi.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove kontakt osobe \
        /// POST /api/kontaktOsoba \
        /// {     \
        ///     "kontaktOsobaIme": "ImePrimer", \
        ///     "kontaktOsobaPrezime": "PrezimePrimer", \
        ///     "funkcija": "FunkcijaPrimer", \
        ///     "telefon": "111234565"
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreiranu kontakt osobu</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpPost]
        public async Task<IActionResult> CreateKontaktOsoba([FromBody] KontaktOsobaCreateDto kOsobaDTO)
        {
            try
            {
                var kOsoba = _mapper.Map<KontaktOsoba>(kOsobaDTO);

                kOsoba.KontaktOsobaId = Guid.NewGuid();

                await _unitOfWork.KontaktOsoba.Insert(kOsoba);

                await _unitOfWork.Save();

                return CreatedAtRoute("GetKontaktOsoba", new { id = kOsoba.KontaktOsobaId }, kOsoba);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Insert error.");
            }
        }

        /// <summary>
        /// Ažurira jednu kontakt osobu.
        /// </summary>
        /// <param name="kOsobaDTO">Model kontakt osobe koja se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj kontakt osobi.</returns>
        /// <response code="200">Kontakt osoba uspesno azurirana</response>
        /// <response code="404">Kontakt osoba koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpPut]
        public async Task<IActionResult> UpdateKontaktOsoba([FromBody] KontaktOsobaUpdateDto kOsobaDTO)
        {

            try
            {
                var kOsoba = await _unitOfWork.KontaktOsoba.Get(i => i.KontaktOsobaId == kOsobaDTO.KontaktOsobaId);

                if (kOsoba == null) return NotFound();

                _mapper.Map(kOsobaDTO, kOsoba);

                _unitOfWork.KontaktOsoba.Update(kOsoba);

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
        /// Vrši brisanje jedne kontakt osobe na osnovu ID-ja kontakt osobe.
        /// </summary>
        /// <param name="id">ID kontakt osobe</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Kontakt osoba uspešno obrisana</response>
        /// <response code="404">Nije pronađena kontakt osoba za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteKontaktOsoba(Guid id)
        {
            try
            {
                var kOsoba = await _unitOfWork.KontaktOsoba.Get(i => i.KontaktOsobaId == id);

                if (kOsoba == null) return NotFound();

                await _unitOfWork.KontaktOsoba.Delete(id);

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
