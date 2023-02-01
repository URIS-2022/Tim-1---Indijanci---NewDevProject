using AutoMapper;
using Licitacija.Services.KupacAPI.DTOs.KupacDTO;
using Licitacija.Services.KupacAPI.DTOs.PravnoLiceDTOs;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.ConcreteClasses;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KupacAPI.Controllers
{
    [ApiController]
    [Route("api/kupac")]
    [Produces("application/json", "application/xml")]
    public class KupacController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKupacRepository _kupacRepository;
        private readonly IMapper _mapper;

        public KupacController(IUnitOfWork unitOfWork, IKupacRepository kupacRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _kupacRepository = kupacRepository;
            _mapper = mapper;   
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetKupci()
        {
            try
            {
                var kupci = await _kupacRepository.GetAll();

                if (kupci == null) return NoContent();

                var results = _mapper.Map<List<KupacDTO>>(kupci);

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id:guid}", Name = "GetKupac")]
        public async Task<IActionResult> GetKupac(Guid id)
        {
            try
            {
                var kupac = await _kupacRepository.Get(id);

                if (kupac == null) return NotFound();

                var result = _mapper.Map<KupacDTO>(kupac);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> CreateKupac([FromBody] KupacCreateDTO kupacDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var kupac = _mapper.Map<Kupac>(kupacDTO);

                kupac.KupacId = Guid.NewGuid();

                await _unitOfWork.Kupac.Insert(kupac);

                await _unitOfWork.Save();

                return CreatedAtRoute("GetKupac", new { id = kupac.KupacId }, kupac);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Insert error.");
            }
        }

        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> UpdateKupac([FromBody] KupacUpdateDTO kupacDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var kupac = await _unitOfWork.Kupac.Get(i => i.KupacId == kupacDTO.KupacId);

                if (kupac == null) return NotFound();

                _mapper.Map(kupacDTO, kupac);

                _unitOfWork.Kupac.Update(kupac);

                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Update error.");
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteKupac(Guid id)
        {
            try
            {
                var kupac = await _unitOfWork.Kupac.Get(i => i.KupacId == id);

                if (kupac == null) return NotFound();

                await _unitOfWork.Kupac.Delete(id);

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
