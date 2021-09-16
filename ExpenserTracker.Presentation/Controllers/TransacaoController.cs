using Expenser_Tracker.Domain.Entities;
using ExpenserTracker.Application.DTO;
using ExpenserTracker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExpenserTracker.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoAppService _transacaoAppService;

        public TransacaoController(ITransacaoAppService transacaoAppService)
        {
            _transacaoAppService = transacaoAppService;
        }

        [HttpPost, Route("criar")]
        public async void Create(TransacaoCadastro_DTO model)
        {
            _transacaoAppService.Criar(model);
        }

        [HttpDelete, Route("deletar/{id}")]
        public async void Delete(int id)
        {
            _transacaoAppService.Remove(_transacaoAppService.GetById(id));
        }

        [HttpGet, Route("")]
        public IEnumerable<Transacao> GetAll()
        {
            return _transacaoAppService.GetAll();
        }
    }
}
