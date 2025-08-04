using api_livros.Application.Interfaces;
using api_livros.Application.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api_livros.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var result = await _service.GetUsuarios();

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var result = await _service.GetUsuarioById(id);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario(UsuarioInputModel model)
        {
            var result = await _service.PostUsuario(model);

            return CreatedAtAction(nameof(GetUsuarioById), new { id = result.Data?.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(AlteracaoUsuarioInputModel model)
        {
            var result = await _service.PutUsuario(model);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var result = await _service.DeleteUsuario(id);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
