using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Services;
using Licitacija.Services.Gateway.Services.Implementation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Licitacija.Services.Gateway.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdresaController : ControllerBase
    {
        private readonly IAdresaService _adresaServis;

        public AdresaController(IAdresaService adresaServis)
        {
            _adresaServis = adresaServis;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdresa()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _adresaServis.GetAdresa<List<AdresaDTO>>(token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAdresaById(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _adresaServis.GetAdresaById<AdresaDTO>(id, token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpGet("adresaBezDrzave/{id:guid}")]
        public async Task<IActionResult> GetAdresaBezDrzave(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _adresaServis.GetAdresaById<AdresaExchangeDTO>(id, token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdresa(AdresaCreateDTO adresaDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _adresaServis.CreateAdresa<string>(adresaDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdresa(AdresaUpdateDTO adresaDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _adresaServis.UpdateAdresa<string>(adresaDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAdresa(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _adresaServis.DeleteAdresa<string>(id, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }
    }
}
