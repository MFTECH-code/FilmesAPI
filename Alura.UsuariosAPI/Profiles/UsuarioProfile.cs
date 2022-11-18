using Alura.UsuariosAPI.Data.Dtos;
using Alura.UsuariosAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Alura.UsuariosAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDTO, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
            CreateMap<Usuario, CustomIdentityUser>();
        }
    }
}
