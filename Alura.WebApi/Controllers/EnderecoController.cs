using Alura.WebApi.Data;
using Alura.WebApi.Data.DTOs.Endereco;
using Alura.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Alura.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<Endereco> RecuperarEnderecos()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if (endereco != null)
            {
                var enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);
                return Ok(enderecoDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                return NotFound();

            _mapper.Map(enderecoDTO, endereco);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            var filme = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if (filme == null)
                return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
