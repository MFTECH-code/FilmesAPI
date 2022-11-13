using Alura.WebApi.Data;
using Alura.WebApi.Data.DTOs;
using Alura.WebApi.Models;
using AutoMapper;
using FluentResults;

namespace Alura.WebApi.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDTO AdicionaFilme(CreateFilmeDTO filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDTO>(filme);
        }

        public List<ReadFilmeDTO>? RecuperarFilmes(int? classificacaoEtaria)
        {
            if (classificacaoEtaria == null)
                return _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.ToList());

            var filmes = _context.Filmes.Where(f => f.ClassificacaoEtaria == classificacaoEtaria).ToList();

            if (filmes == null)
                return null;

            return _mapper.Map<List<ReadFilmeDTO>>(filmes);
        }

        public ReadFilmeDTO? RecuperarFilmePorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme != null)
            {
                var readFilmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
                return readFilmeDTO;
            }

            return null;
        }

        public Result AtualizaFilme(int id, UpdateFilmeDTO filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            
            if (filme == null)
                return Result.Fail("Filme não encontrado");

            _mapper.Map(filmeDto, filme);

            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
                return Result.Fail("Filme não encontrado");

            _context.Remove(filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
