using Expenser_Tracker.Domain.Entities;
using ExpenserTracker.Application.DTO;

namespace ExpenserTracker.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Usuario GetUsuarioForLogin(string email, string senha);
        RetornoBase_DTO CadastrarUsuario(UsuarioCadastro_DTO model_DTO);
        void UploadImagemPerfil();
    }
}
