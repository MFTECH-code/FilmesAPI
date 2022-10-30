using Alura.WebApi.Data.DTOs.Filme;
using Alura.WebApi.Models;
using AutoMapper;

namespace Alura.WebApi.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDTO>();
            CreateMap<UpdateFilmeDTO, Filme>();
        }
    }
}
