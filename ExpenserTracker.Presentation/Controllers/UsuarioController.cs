using Expenser_Tracker.Domain.Entities;
using ExpenserTracker.Application.DTO;
using ExpenserTracker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExpenserTracker.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost, Route("criar")]
        public async Task<IActionResult> Create(UsuarioCadastro_DTO usuario)
        {
            Usuario user = new Usuario
            {
                DataCadastro = DateTime.Now,
                Email = usuario.Email,
                Nome = usuario.Nome,
                Senha = usuario.Senha
            };
            _usuarioAppService.Add(user);
            return Ok();
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_usuarioAppService.GetAll());
        }
    }
}
