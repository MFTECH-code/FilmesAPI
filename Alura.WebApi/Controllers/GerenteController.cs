using Alura.WebApi.Data.DTOs;
using Alura.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Alura.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _service;

        public GerenteController(GerenteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDTO gerenteDTO) 
        {
            var gerente = _service.AdicionaGerente(gerenteDTO);

            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            var gerente = _service.RecuperaGerentePorId(id);

            if (gerente == null)
                return NotFound();

            return Ok(gerente);
        }

        [HttpGet]
        public IEnumerable<ReadGerenteDTO> RecuperaGerentes()
        {
            return _service.RecuperaGerentes();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaGerente(int id, [FromBody]UpdateGerenteDTO gerenteDTO)
        {
            var result = _service.AtualizaGerente(id, gerenteDTO);
            
            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletaGerente(int id)
        {
            var result = _service.DeletaGerente(id);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
