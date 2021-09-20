using Expenser_Tracker.Domain.Entities;

namespace ExpenserTracker.Infra.CrossCutting.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
