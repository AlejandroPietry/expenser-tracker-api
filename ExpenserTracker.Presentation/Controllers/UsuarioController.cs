using ExpenserTracker.Application.DTO;
using ExpenserTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace ExpenserTracker.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Create(UsuarioCadastro_DTO usuario_dto)
        {
            var response = _usuarioAppService.CadastrarUsuario(usuario_dto);
            if (response.Error)
                return Conflict(response);
            return Ok(response);
        }


        [DisableRequestSizeLimit]
        [HttpPost, Route("upload-imagem-perfil")]
        
        public async Task<IActionResult> UploadImagemPerfil(IFormFile image)
        {
            string savePath = string.Concat(@"C:\Users\pietr\Pictures\expenserImages\", image.FileName);

            byte[] bytesFile = FileToByteArray(image);
            await System.IO.File.WriteAllBytesAsync(savePath, bytesFile);
            return Ok();
        }
        private byte[] FileToByteArray(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
