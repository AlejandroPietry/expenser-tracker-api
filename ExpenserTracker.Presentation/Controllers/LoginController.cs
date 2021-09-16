using ExpenserTracker.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace ExpenserTracker.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(Login_DTO model)
        {
            return Ok();
        }
    }
}
