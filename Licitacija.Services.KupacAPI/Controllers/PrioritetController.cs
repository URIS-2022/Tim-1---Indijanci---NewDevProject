using AutoMapper;
using Licitacija.Services.KupacAPI.DTOs.PrioritetDTOs;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KupacAPI.Controllers
{
    [ApiController]
    [Route("api/prioritet")]
    [Produces("application/json", "application/xml")]
    public class PrioritetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrioritetController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve prioritete.
        /// </summary>
        /// <returns>Lista prioriteta.</returns>
        /// <response code="200">Vraća listu prioriteta</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet]
        public async Task<IActionResult> GetPrioriteti()
        {
            try
            {
                var prioriteti = await _unitOfWork.Prioritet.GetAll();

                if (prioriteti == null) return NoContent();

                var results = _mapper.Map<List<PrioritetDto>>(prioriteti);

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Vraća jedan prioritet na osnovu ID-ja prioriteta.
        /// </summary>
        /// <param name="id">ID prioriteta</param>
        /// <returns>Jedan prioritet.</returns>
        /// <response code="200">Vraća traženi prioritet</response>
        /// <response code="404">Nije pronađen nijedan prioritet sa datim ID prioriteta</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet("{id:guid}", Name = "GetPrioritet")]
        public async Task<IActionResult> GetPrioritet(Guid id)
        {
            try
            {
                var prioritet = await _unitOfWork.Prioritet.Get(i => i.PrioritetId == id);

                if (prioritet == null) return NotFound();

                var result = _mapper.Map<PrioritetDto>(prioritet);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Kreira novi prioritet.
        /// </summary>
        /// <param name="prioritetDTO">Model prioriteta</param>
        /// <returns>Potvrda o kreiranom prioritetu.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog prioriteta \
        /// POST /api/prioritet \
        /// {     \
        ///     "prioritetNaziv": "PrioritetPrimer" \
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreirani prioritet</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpPost]
        public async Task<IActionResult> CreatePrioritet([FromBody] PrioritetCreateDto prioritetDTO)
        {
            try
            {
                var prioritet = _mapper.Map<Prioritet>(prioritetDTO);

                prioritet.PrioritetId = Guid.NewGuid();

                await _unitOfWork.Prioritet.Insert(prioritet);

                await _unitOfWork.Save();

                return CreatedAtRoute("GetPrioritet", new { id = prioritet.PrioritetId }, prioritet);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Insert error.");
            }
        }

        /// <summary>
        /// Ažurira jedan prioritet.
        /// </summary>
        /// <param name="prioritetDTO">Model prioriteta koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom prioritetu.</returns>
        /// <response code="200">Prioritet uspešno ažuriran</response>
        /// <response code="404">Prioritet koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpPut]
        public async Task<IActionResult> UpdatePrioritet([FromBody] PrioritetUpdateDto prioritetDTO)
        {
            try
            {
                var prioritet = await _unitOfWork.Prioritet.Get(i => i.PrioritetId == prioritetDTO.PrioritetId); 

                if (prioritet == null) return NotFound();

                _mapper.Map(prioritetDTO, prioritet);

                _unitOfWork.Prioritet.Update(prioritet);

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
        /// Vrši brisanje jednog prioriteta na osnovu ID-ja prioriteta.
        /// </summary>
        /// <param name="id">ID prioriteta</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Prioritet uspešno obrisan</response>
        /// <response code="404">Nije pronađen prioritet za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePrioritet(Guid id)
        {
            try
            {
                var prioritet = await _unitOfWork.Prioritet.Get(i => i.PrioritetId == id); 

                if (prioritet == null) return NotFound();

                await _unitOfWork.Prioritet.Delete(id);

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
