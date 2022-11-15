using Alura.UsuariosAPI.Data.Dtos;
using Alura.UsuariosAPI.Data.Requests;
using Alura.UsuariosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Alura.UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastraUsuarioAsync([FromBody] CreateUsuarioDTO createDTO)
        {
            var result = await _cadastroService.CadastraUsuarioAsync(createDTO);
            if (result.IsFailed) return StatusCode(500);
            return Ok(new { ConfirmationToken = result.Successes.First().Message });
        }


        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
        {
            var result = _cadastroService.AtivaContaUsuario(request);
            if (result.IsFailed) return StatusCode(500);
            return Ok();
        }

    }
}
