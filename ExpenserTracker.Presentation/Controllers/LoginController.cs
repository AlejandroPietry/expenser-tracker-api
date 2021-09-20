using ExpenserTracker.Application.DTO;
using ExpenserTracker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace ExpenserTracker.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService _loginAppService;

        public LoginController(ILoginAppService loginAppService)
        {
            this._loginAppService = loginAppService;
        }

        [HttpPost, Route("login")]
        public async Task<LoginRetorno_DTO> Login(Login_DTO model)
        {
            return _loginAppService.Logar(model);
        }
    }
}
