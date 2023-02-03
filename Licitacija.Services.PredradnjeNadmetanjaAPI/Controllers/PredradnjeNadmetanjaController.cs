﻿using AutoMapper;
using Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs;
using Licitacija.Services.PredradnjeNadmetanjaAPI.Entities;
using Licitacija.Services.PredradnjeNadmetanjaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Controllers
{
    [Route("api/predradnjeNadmetanja")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class PredradnjeNadmetanjaController : Controller
    {
        private readonly IPredradnjeNadmetanjaRepository _predradnjeNadmetanja;
        private readonly IMapper _mapper;

        public PredradnjeNadmetanjaController(IPredradnjeNadmetanjaRepository predradnjeNadmetanja, IMapper mapper)  
        {
            _predradnjeNadmetanja = predradnjeNadmetanja;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetPredradnjeNadmetanja()
        {
            try
            {
                var predradnje = await _predradnjeNadmetanja.GetAll();

                if (predradnje == null) return NoContent();

                var results = _mapper.Map<List<PredradnjeNadmetanjaDTO>>(predradnje);//mapiranje (iz) <u>

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
        [HttpGet("{id:guid}", Name = "GetPredradnjaNadmetanja")]
        public async Task<IActionResult> GetPredradnjaNadmetanja(Guid id)
        {
            try
            {
                var predradnja = await _predradnjeNadmetanja.Get(i => i.PredradnjeNadmetanjaId == id);

                if (predradnja == null) return NotFound();

                var result = _mapper.Map<PredradnjeNadmetanjaDTO>(predradnja);

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
        public async Task<IActionResult> CreatePredradnjaNadmetanja([FromBody] PredradnjeNadmetanjaCreateDTO predradnjeDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

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

        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> UpdatePredradnjaNadmetanja([FromBody] PredradnjeNadmetanjaUpdateDTO predradnjeDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

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

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

    }
}
