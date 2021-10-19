using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Servicos;
using ExpenserTracker.Application.DTO;
using ExpenserTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenserTracker.Application
{
    public class TransacaoAppService : AppServiceBase<Transacao>, ITransacaoAppService
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoAppService(ITransacaoService transacaoService) : base(transacaoService)
        {
            _transacaoService = transacaoService;
        }

        public void Criar(TransacaoCadastro_DTO model, string guildUserId)
        {
            _transacaoService.Add(new Transacao()
            {
                TipoTransacao = model.TipoTransacao,
                Titulo = model.Titulo,
                Valor = model.Valor,
                DataCadastro = DateTime.Now,

                IdUsuario = Guid.Parse(guildUserId)
            });
        }

        public void DeletarTodosDoUsuario(string idUsuario)
        {
            _transacaoService.DeletarTodosDoUsuario(Guid.Parse(idUsuario));
        }

        public IEnumerable<TransacaoRetorno_DTO> GetAllByUserId(string userId)
        {

            var listaBanco = _transacaoService.GetAllByUserId(Guid.Parse(userId));
            return listaBanco.Select(x => new TransacaoRetorno_DTO
            {
                Id = x.Id,
                TipoTransacao = x.TipoTransacao,
                Titulo = x.Titulo,
                Valor = x.Valor
            });
        }
    }
}
