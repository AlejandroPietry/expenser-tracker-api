using AutoMapper;
using Expenser_Tracker.Domain.Entities;
using ExpenserTracker.Application.DTO;

namespace ExpenserTracker.Application.AutoMapper
{
    public class TransacaoCadastroToTransacao : Profile
    {
        public TransacaoCadastroToTransacao()
        {
            CreateMap<TransacaoCadastro_DTO, Transacao>();
        }
    }
}
