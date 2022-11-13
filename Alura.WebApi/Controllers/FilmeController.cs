using Alura.WebApi.Data;
using Alura.WebApi.Data.DTOs;
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
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            if (classificacaoEtaria == null)
                return Ok(_mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.ToList()));
            
            var filmes = _context.Filmes.Where(f => f.ClassificacaoEtaria == classificacaoEtaria).ToList();

            if (filmes == null)
                return NotFound();
            
            return Ok(_mapper.Map<List<ReadFilmeDTO>>(filmes));
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
