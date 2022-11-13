using Alura.WebApi.Data.DTOs.Sessao;
using Alura.WebApi.Models;
using AutoMapper;

namespace Alura.WebApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * -1)));
        }
    }
}
