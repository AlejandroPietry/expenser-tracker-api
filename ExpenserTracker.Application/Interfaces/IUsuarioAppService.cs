using Expenser_Tracker.Domain.Entities;

namespace ExpenserTracker.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Usuario GetUsuarioForLogin(string email, string senha);
    }
}
