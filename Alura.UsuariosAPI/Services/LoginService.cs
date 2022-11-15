using Alura.UsuariosAPI.Data.Requests;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Alura.UsuariosAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity =  _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);

            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(u => u.NormalizedUserName == request.Username.ToUpper());
                
                var token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login Falhou");
        }

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            var identityUser = RecuperaUsuarioPorEmail(request.Email);
            if (identityUser != null)
            {
                var codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }
            return Result.Fail("Falha ao solicitar redefinição");

        }

        public Result EfetuaResetSenhaUsuario(EfetuaResetRequest request)
        {
            var identityUser = RecuperaUsuarioPorEmail(request.Email);
            var resultIdentity = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;
            if (resultIdentity.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso");
            return Result.Fail("Houve um erro na operação");
        }

        private IdentityUser<int>? RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }

    }
}
