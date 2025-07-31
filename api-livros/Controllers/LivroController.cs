using api_livros.Application.Interfaces;
using api_livros.Application.Models.InputModels;
using api_livros.Application.Models.ViewModels;
using api_livros.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_livros.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _service;

        public LivroController(ILivroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetLivro()
        {
            var result = await _service.GetLivros();

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLivroById(int id)
        {
            var result = await _service.GetLivroById(id);

            if(!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> PostLivro(LivroInputModel model)
        {
            var result = await _service.PostLivro(model);

            return CreatedAtAction(nameof(GetLivroById), new {id = result.Data?.Id}, result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var result = await _service.DeleteLivro(id);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
