using Alura.UsuariosAPI.Data.Dtos;
using Alura.UsuariosAPI.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Alura.UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Result> CadastraUsuarioAsync(CreateUsuarioDTO createDTO)
        {
            var usuario = _mapper.Map<Usuario>(createDTO);
            var identityUser = _mapper.Map<IdentityUser<int>>(usuario);
            var resultadoIdentity = await _userManager.CreateAsync(identityUser, createDTO.Password);
            if (resultadoIdentity.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário");
        }
    }
}
