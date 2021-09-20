﻿using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Servicos;
using ExpenserTracker.Application.Interfaces;

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
    }
}
