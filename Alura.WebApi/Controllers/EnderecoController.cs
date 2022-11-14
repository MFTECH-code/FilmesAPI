using Alura.WebApi.Data.DTOs;
using Alura.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Alura.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
        {
            var endereco = _service.AdicionaEndereco(enderecoDTO);
            
            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDTO> RecuperarEnderecos()
        {
            return _service.RecuperaEnderecos();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            var endereco = _service.RecuperaEnderecoPorId(id);
            
            if (endereco == null)
                return NotFound();
            
            return Ok(endereco);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
        {
            var result = _service.AtualizaEndereco(id, enderecoDTO);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            var result = _service.DeletaEndereco(id);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
