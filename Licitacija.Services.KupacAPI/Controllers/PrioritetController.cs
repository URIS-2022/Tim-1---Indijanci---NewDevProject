using AutoMapper;
using Licitacija.Services.KupacAPI.DTOs.PrioritetDTOs;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KupacAPI.Controllers
{
    [ApiController]
    [Route("api/prioritet")]
    public class PrioritetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPrioritetRepository _prioritetRepository;
        private readonly IMapper _mapper;

        public PrioritetController(IUnitOfWork unitOfWork, IPrioritetRepository prioritetRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _prioritetRepository = prioritetRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrioriteti()
        {
            try
            {
                var prioriteti = await _prioritetRepository.GetAll();

                if (prioriteti == null) return NoContent();

                var results = _mapper.Map<List<PrioritetDTO>>(prioriteti);

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id:guid}", Name = "GetPrioritet")]
        public async Task<IActionResult> GetPrioritet(Guid id)
        {
            try
            {
                var prioritet = await _prioritetRepository.Get(id);

                if (prioritet == null) return NotFound();

                var result = _mapper.Map<PrioritetDTO>(prioritet);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrioritet([FromBody] PrioritetCreateDTO prioritetDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

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

        [HttpPut]
        public async Task<IActionResult> UpdatePrioritet([FromBody] PrioritetUpdateDTO prioritetDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var prioritet = await _prioritetRepository.Get(prioritetDTO.PrioritetId);

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

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePrioritet(Guid id)
        {
            try
            {
                var prioritet = await _prioritetRepository.Get(id);

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
