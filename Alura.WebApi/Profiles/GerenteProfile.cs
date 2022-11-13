using Alura.WebApi.Data.DTOs;
using Alura.WebApi.Models;
using AutoMapper;

namespace Alura.WebApi.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>()
                .ForMember(g => g.Cinemas, opts => opts
                .MapFrom(g => g.Cinemas.Select(
                    c => new {c.Id, c.Nome, c.Endereco, c.EnderecoId})));
            CreateMap<UpdateGerenteDTO, Gerente>();
        }
    }
}
