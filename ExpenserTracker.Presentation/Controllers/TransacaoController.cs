using Expenser_Tracker.Domain.Entities;
using ExpenserTracker.Application.Interfaces;
using ExpenserTracker.Presentation.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
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

            _transacaoAppService.Add(new Transacao() 
            {
                TipoTransacao = model.TipoTransacao,
                Titulo = model.Titulo,
                Valor = model.Valor,
                DataCadastro = DateTime.Now,
                IdUsuario = Guid.Parse("cee9bb42-6f41-40e4-beeb-3ca160e073c6"/*User.FindFirst("id").Value*/)
            });
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
