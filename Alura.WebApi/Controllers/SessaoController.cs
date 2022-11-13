using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.WebApi.Data;
using Alura.WebApi.Models;
using AutoMapper;
using Alura.WebApi.Data.DTOs.Sessao;

namespace Alura.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<Sessao> RecuperaSessoes()
        {
            return _context.Sessoes
                .Include(s => s.Filme)
                .Include(s => s.Cinema)
                .ThenInclude(c => c.Endereco)
                .Include(s => s.Cinema)
                .ThenInclude(c => c.Gerente)
                .AsQueryable();
        }

        [HttpGet("{id}")]
        public ActionResult<ReadSessaoDTO> RecuperaSessaoPorId(int id)
        {
            var sessao = _context.Sessoes
                .Include(s => s.Filme)
                .Include(s => s.Cinema)
                .ThenInclude(c => c.Endereco)
                .Include(s => s.Cinema)
                .ThenInclude(c => c.Gerente)
                .AsQueryable()
                .FirstOrDefault(s => s.Id == id);

            if (sessao == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReadSessaoDTO>(sessao);
        }


        [HttpPost]
        public ActionResult<Sessao> AdicionaSessao(CreateSessaoDTO sessaoDTO)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDTO);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction("RecuperaSessaoPorId", new { id = sessao.Id }, sessao);
        }

    }
}
