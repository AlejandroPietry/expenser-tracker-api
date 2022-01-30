using Expenser_Tracker.Domain.Entities;
using Expenser_Tracker.Domain.Interfaces.Servicos;
using ExpenserTracker.Application.DTO;
using ExpenserTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace ExpenserTracker.Application
{
    public class TransacaoAppService : AppServiceBase<Transacao>, ITransacaoAppService
    {
        private readonly ITransacaoService _transacaoService;
        private readonly IMapper _mapper;

        public TransacaoAppService(ITransacaoService transacaoService, IMapper mapper) : base(transacaoService)
        {
            _transacaoService = transacaoService;
            _mapper = mapper;
        }

        public void Criar(TransacaoCadastro_DTO model, string guildUserId)
        {

            var transacao = _mapper.Map<Transacao>(model);
            transacao.DataCadastro = DateTime.Now;
            transacao.IdUsuario = Guid.Parse(guildUserId);

            _transacaoService.Add(transacao);
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
