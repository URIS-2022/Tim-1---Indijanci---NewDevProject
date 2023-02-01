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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetPravnaLica()
        {
            try
            {
                var pLica = await _pravnoLiceRepository.GetAll();

                if (pLica == null) return NoContent();

                var results = _mapper.Map<List<PravnoLiceDTO>>(pLica);

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
        [HttpGet("{id:guid}", Name = "GetPravnoLice")]
        public async Task<IActionResult> GetPravnoLice(Guid id)
        {
            try
            {
                var pLice = await _pravnoLiceRepository.Get(id);

                if (pLice == null) return NotFound();

                var result = _mapper.Map<PravnoLiceDTO>(pLice);

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
        public async Task<IActionResult> CreatePravnoLice([FromBody] PravnoLiceCreateDTO pLiceDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

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

        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> UpdatePravnoLice([FromBody] PravnoLiceUpdateDTO pLiceDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

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

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
