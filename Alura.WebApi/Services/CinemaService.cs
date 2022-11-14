using Alura.WebApi.Data;
using Alura.WebApi.Data.DTOs;
using Alura.WebApi.Models;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Alura.WebApi.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDTO AdicionaCinema(CreateCinemaDTO cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return _mapper.Map<ReadCinemaDTO>(cinema);
        }

        public List<ReadCinemaDTO> RecuperaCinemas()
        {
            var cinemas = _context.Cinemas
                .Include(c => c.Endereco)
                .Include(c => c.Gerente);

            return _mapper.Map<List<ReadCinemaDTO>>(cinemas);
        }

        public ReadCinemaDTO? RecuperaCinemaPorId(int id)
        {
            var cinema = _context.Cinemas
                .Include(c => c.Endereco)
                .Include(c => c.Gerente)
                .FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                return _mapper.Map<ReadCinemaDTO>(cinema);
            }
            return null;
        }

        public Result AtualizaCinema(int id, UpdateCinemaDTO cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            
            if (cinema == null)
                return Result.Fail("Cinema não encontrado");
            
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null)
                return Result.Fail("Cinema não encontrado");
            
            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
