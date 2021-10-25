using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Servicos;
using ExpenserTracker.Application.DTO;
using ExpenserTracker.Application.Interfaces;
using System;

namespace ExpenserTracker.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioAppService(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Usuario GetUsuarioForLogin(string email, string senha)
        {
            return _usuarioService
                .GetUsuarioByExpression(e => e.Email == email && e.Senha == senha);
        }

        public RetornoBase_DTO CadastrarUsuario(UsuarioCadastro_DTO model_DTO)
        {
            if(_usuarioService.GetUsuarioByExpression(x => x.Email == model_DTO.Email) != null)
            {
                return new RetornoBase_DTO { Error = true, ErrorMessage = "O email já está sendo utilizado!" };
            }

            Usuario user = new ()
            {
                DataCadastro = DateTime.Now,
                Email = model_DTO.Email,
                Nome = model_DTO.Nome,
                Senha = model_DTO.Senha
            };

            Add(user);
            return new RetornoBase_DTO { Error = false };
        }
    }
}
