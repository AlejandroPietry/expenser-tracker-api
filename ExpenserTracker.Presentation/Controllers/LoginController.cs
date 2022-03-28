using ExpenserTracker.Application.DTO;
using ExpenserTracker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

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

        [HttpGet("/get-data-async")]
        public IAsyncEnumerable<int> GetDataAsync()
        {
            return GetNumbers();
        }

        private static async IAsyncEnumerable<int> GetNumbers()
        {
            for(int i = 0; i <=10; i++)
            {
                await Task.Delay(1000);
                yield return i;
            }
        }
    }
}
