using ExpenserTracker.Application.DTO;
using ExpenserTracker.Application.Interfaces;
using ExpenserTracker.Infra.CrossCutting.Services.Interfaces;

namespace ExpenserTracker.Application
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly ITokenService _tokenService;
        public LoginAppService(IUsuarioAppService usuarioAppService, ITokenService tokenService)
        {
            this._usuarioAppService = usuarioAppService;
            this._tokenService = tokenService;
        }

        public LoginRetorno_DTO Logar(Login_DTO loginData)
        {
           var usuario = _usuarioAppService.GetUsuarioForLogin(loginData.Email, loginData.Senha);

            if (usuario is null)
                return new LoginRetorno_DTO {Error = true, ErrorMessage = "Email ou senha incorretos" };

            string jwtToken =_tokenService.GenerateToken(usuario);

            return new LoginRetorno_DTO
            {
                Error = false,
                JwtToken = jwtToken,
                Nome = usuario.Nome
            };
        }
    }
}
