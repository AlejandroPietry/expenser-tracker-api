using ExpenserTracker.Application.DTO;
using ExpenserTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ExpenserTracker.Presentation.Hubs;
using System;

namespace ExpenserTracker.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoAppService _transacaoAppService;
        private IHubContext<NotifyHub> _notifyHubSocket;

        public TransacaoController(ITransacaoAppService transacaoAppService, IHubContext<NotifyHub> notifyHubSocket)
        {
            _transacaoAppService = transacaoAppService;
            _notifyHubSocket = notifyHubSocket;
        }

        [HttpPost, Route("")]
        public async Task Create(TransacaoCadastro_DTO model)
        {
            _transacaoAppService.Criar(model, User.FindFirst("id").Value);
        }

        [HttpDelete, Route("deletar/{id}")]
        public async Task Delete(int id)
        {
            _transacaoAppService.Remove(_transacaoAppService.GetById(id));
        }
        [HttpGet, Route("all-by-user")]
        public async Task<IEnumerable<TransacaoRetorno_DTO>> GetAllByUserId()
        {
            return _transacaoAppService.GetAllByUserId(User.FindFirst("id").Value);
        }

        [HttpGet, Route("deletar-todos")]
        public async Task DeleteAllByUserId()
        {
            _transacaoAppService.DeletarTodosDoUsuario(User.FindFirst("id").Value);
        }

        [HttpGet, Route("sincronizar-dfe")]
        public async Task SincronizarDfe()
        {
            for(int i = 0; i <= 5; i++)
            {
                await Task.Delay(600);
                var nota = new TransacaoRetorno_DTO()
                {
                    Id = i,
                    Titulo = "Econet Editora",
                    Valor = new Random().Next(11,100)
                };
                await _notifyHubSocket.Clients.All.SendAsync("12345", nota);
            }
            await _notifyHubSocket.Clients.All.SendAsync("acabou", "Notas Localizadas");
        }
    }
}
