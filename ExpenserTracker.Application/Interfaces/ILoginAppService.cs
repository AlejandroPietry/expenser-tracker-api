using ExpenserTracker.Application.DTO;

namespace ExpenserTracker.Application.Interfaces
{
    public interface ILoginAppService
    {
        LoginRetorno_DTO Logar(Login_DTO loginData);
    }
}
