using Alura.WebApi.Data;
using Alura.WebApi.Data.DTOs.Filme;
using Alura.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Alura.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme != null)
            {
                var readFilmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
                return Ok(readFilmeDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
                return NotFound();

            _mapper.Map(filmeDto, filme);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
                return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
