using Alura.WebApi.Data;
using Alura.WebApi.Data.DTOs;
using Alura.WebApi.Models;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Alura.WebApi.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDTO AdicionaGerente(CreateGerenteDTO gerenteDTO)
        {
            var gerente = _mapper.Map<Gerente>(gerenteDTO);
            
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            
            return _mapper.Map<ReadGerenteDTO>(gerente);
        }

        public ReadGerenteDTO? RecuperaGerentePorId(int id)
        {
            var gerente = _context.Gerentes
                .Include(g => g.Cinemas)
                .ThenInclude(c => c.Endereco)
                .FirstOrDefault(g => g.Id == id);
            
            if (gerente != null)
                return _mapper.Map<ReadGerenteDTO>(gerente);

            return null;
        }

        public List<ReadGerenteDTO> RecuperaGerentes()
        {
            var gerentes = _context.Gerentes
                .Include(g => g.Cinemas)
                .ThenInclude(c => c.Endereco);

            return _mapper.Map<List<ReadGerenteDTO>>(gerentes);
        }

        public Result AtualizaGerente(int id, UpdateGerenteDTO gerenteDTO)
        {
            var gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
            
            if (gerente == null)
                return Result.Fail("Gerente não encontrado");

            gerente.Nome = gerenteDTO.Nome;
            _context.SaveChanges();
            
            return Result.Ok();
        }

        public Result DeletaGerente(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
            
            if (gerente == null)
                return Result.Fail("Gerente não encontrado");

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
