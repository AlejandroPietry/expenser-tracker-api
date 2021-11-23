using Expenser_Tracker.Domain.Entities;
using ExpenserTracker.Application.DTO;
using ExpenserTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenserTracker.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoAppService _transacaoAppService;

        public TransacaoController(ITransacaoAppService transacaoAppService)
        {
            _transacaoAppService = transacaoAppService;
        }

        [HttpPost, Route("")]
        public async void Create(TransacaoCadastro_DTO model)
        {
            _transacaoAppService.Criar(model, User.FindFirst("id").Value);
        }

        [HttpDelete, Route("deletar/{id}")]
        public async void Delete(int id)
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

        [HttpGet, Route("")]
        public IEnumerable<Transacao> GetAll()
        {
            return _transacaoAppService.GetAll();
        }
    }
}
