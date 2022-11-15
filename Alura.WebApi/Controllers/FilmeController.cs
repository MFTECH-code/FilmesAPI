using Alura.WebApi.Data.DTOs;
using Alura.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alura.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _service;

        public FilmeController(FilmeService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            var filme = _service.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            var filmes = _service.RecuperarFilmes(classificacaoEtaria);
            
            if (filmes == null)
                return NotFound();

            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            var filme = _service.RecuperarFilmePorId(id);
            
            if (filme == null)
                return NotFound();
            
            return Ok(filme);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDto)
        {
            var result = _service.AtualizaFilme(id, filmeDto);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var result = _service.DeletaFilme(id);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
