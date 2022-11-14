using Alura.WebApi.Data;
using Alura.WebApi.Data.DTOs;
using Alura.WebApi.Models;
using AutoMapper;
using FluentResults;

namespace Alura.WebApi.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDTO AdicionaEndereco(CreateEnderecoDTO enderecoDTO)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDTO);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return _mapper.Map<ReadEnderecoDTO>(endereco);
        }

        public List<ReadEnderecoDTO> RecuperaEnderecos()
        {
            var enderecos = _context.Enderecos;

            return _mapper.Map<List<ReadEnderecoDTO>>(enderecos);
        }

        public ReadEnderecoDTO? RecuperaEnderecoPorId(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            
            if (endereco != null)
                return _mapper.Map<ReadEnderecoDTO>(endereco);
            
            return null;
        }

        public Result AtualizaEndereco(int id, UpdateEnderecoDTO enderecoDTO)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            
            if (endereco == null)
                return Result.Fail("Endereço não encontrado");

            _mapper.Map(enderecoDTO, endereco);

            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                return Result.Fail("Endereço não encontrado");

            _context.Enderecos.Remove(endereco);

            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
