using Alura.WebApi.Data;
using Alura.WebApi.Data.DTOs;
using Alura.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alura.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDTO gerenteDTO) 
        {
            var gerente = _mapper.Map<Gerente>(gerenteDTO);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            var gerente = _context.Gerentes
                .Include(g => g.Cinemas)
                .ThenInclude(c => c.Endereco)
                .FirstOrDefault(g => g.Id == id);
            if (gerente == null)
                return NotFound();

            var gerenteDTO = _mapper.Map<ReadGerenteDTO>(gerente);
            return Ok(gerenteDTO);
        }

        [HttpGet]
        public IEnumerable<Gerente> RecuperaGerentes()
        {
            return _context.Gerentes
                .Include(g => g.Cinemas);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaGerente(int id, [FromBody]UpdateGerenteDTO gerenteDTO)
        {
            var gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
            if (gerente == null)
                return NotFound();

            gerente.Nome = gerenteDTO.Nome;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletaGerente(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
            if (gerente == null)
                return NotFound();

            _context.Gerentes.Remove(gerente);
            return NoContent();
        }
    }
}
