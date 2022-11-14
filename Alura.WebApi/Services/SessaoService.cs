using Alura.WebApi.Data;
using Alura.WebApi.Data.DTOs.Sessao;
using Alura.WebApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alura.WebApi.Services
{
    public class SessaoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadSessaoDTO> RecuperaSessoes()
        {
            var sessoes = _context.Sessoes
                .Include(s => s.Filme)
                .Include(s => s.Cinema)
                .ThenInclude(c => c.Endereco)
                .Include(s => s.Cinema)
                .ThenInclude(c => c.Gerente);

            return _mapper.Map<List<ReadSessaoDTO>>(sessoes);
        }

        public ReadSessaoDTO? RecuperaSessaoPorId(int id)
        {
            var sessao = _context.Sessoes
                .Include(s => s.Filme)
                .Include(s => s.Cinema)
                .ThenInclude(c => c.Endereco)
                .Include(s => s.Cinema)
                .ThenInclude(c => c.Gerente)
                .FirstOrDefault(s => s.Id == id);

            if (sessao != null)
            {
                return _mapper.Map<ReadSessaoDTO>(sessao);
            }
            
            return null;
        }

        public Sessao AdicionaSessao(CreateSessaoDTO sessaoDTO)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDTO);
            
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return sessao;
        }
    }
}
