using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.Gateway.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UplataController : ControllerBase
    {
        private readonly IUplataService _uplataService;

        public UplataController(IUplataService uplataService)
        {
            _uplataService = uplataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUplata()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _uplataService.GetUplata<List<UplataDto>>(token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUplataById(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _uplataService.GetUplataById<UplataDto>(id, token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateUplata(UplataCreateDto uplataDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _uplataService.CreateUplata<string>(uplataDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUplata(UplataUpdateDto uplataDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _uplataService.UpdateUplata<string>(uplataDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUplata(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _uplataService.DeleteUplata<string>(id, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }
    }
}
