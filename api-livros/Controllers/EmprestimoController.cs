using api_livros.Application.Models.InputModels;
using api_livros.Application.Models.ViewModels;
using api_livros.Core.Entities;
using api_livros.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_livros.Controllers
{
    [ApiController]
    [Route("api/emprestimo")]
    public class EmprestimoController : ControllerBase
    {
        private readonly LivroDbContext _db;
        public EmprestimoController(LivroDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> PostEmprestimo(EmprestimoInputModel model)
        {
            var emprestimo = model.ToEntity();

            await _db.Emprestimos.AddAsync(emprestimo);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetEmprestimos()
        {
            var emprestimos = await _db.Emprestimos
                                        .Include(p => p.Livro)
                                        .Include(p => p.Usuario)
                                        .ToListAsync();

            if (!emprestimos.Any())
            {
                return NotFound();
            }

            var model = emprestimos.Select(o => EmprestimoViewModel.FromEntity(o)).ToList();

            return Ok(model);
        }

    }
}
