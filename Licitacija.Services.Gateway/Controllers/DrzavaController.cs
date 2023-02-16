using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.Gateway.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DrzavaController : ControllerBase
    {
        private readonly IDrzavaService _drzavaServis;

        public DrzavaController(IDrzavaService drzavaServis)
        {
            _drzavaServis = drzavaServis;
        }

        [HttpGet]
        public async Task<IActionResult> GetDrzava()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _drzavaServis.GetDrzava<List<DrzavaDTO>>(token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDrzavaById(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _drzavaServis.GetDrzavaById<DrzavaDTO>(id, token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdresa(DrzavaCreateDTO drzavaDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _drzavaServis.CreateDrzava<string>(drzavaDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdresa(DrzavaUpdateDTO drzavaDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _drzavaServis.UpdateDrzava<string>(drzavaDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteDrzava(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _drzavaServis.DeleteDrzava<string>(id, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }
    }
}
