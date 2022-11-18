using Alura.UsuariosAPI.Data.Dtos;
using Alura.UsuariosAPI.Data.Requests;
using Alura.UsuariosAPI.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace Alura.UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<Result> CadastraUsuarioAsync(CreateUsuarioDTO createDTO)
        {
            var usuario = _mapper.Map<Usuario>(createDTO);
            var identityUser = _mapper.Map<CustomIdentityUser>(usuario);
            var resultadoIdentity = await _userManager.CreateAsync(identityUser, createDTO.Password);
            _userManager.AddToRoleAsync(identityUser, "regular");
            if (resultadoIdentity.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(
                    new[] { identityUser.Email },
                    "Link de ativação",
                    identityUser.Id, encodedCode);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(u => u.Id == request.UsuarioId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta do usuário");
        }
    }
}
