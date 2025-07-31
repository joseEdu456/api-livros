using api_livros.Application.Interfaces;
using api_livros.Application.Models.InputModels;
using api_livros.Application.Models.ViewModels;
using api_livros.Core.Interfaces;
using api_livros.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace api_livros.Application.Services
{
    public class LivroService : ILivroService
    {
        public ILivroRepository _repository { get; set; }
        public LivroService(ILivroRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> DeleteLivro(int id)
        {
            var livro = await _repository.GetLivroById(id);

            if (livro is null)
            {
                return ResultViewModel.Error("Livro não encontrado");
            }

            livro.SetAsDeleted();

            await _repository.DeleteLivro(livro);

            return ResultViewModel.Sucess();
        }

        public async Task<ResultViewModel<LivroViewModel>> GetLivroById(int id)
        {
            var livro = await _repository.GetLivroById(id);

            if (livro is null)
            {
                return ResultViewModel<LivroViewModel>.Error("Livro não encontrado");
            }

            var model = LivroViewModel.FromEntity(livro);

            return ResultViewModel<LivroViewModel>.Sucess(model);
        }

        public async Task<ResultViewModel<List<LivroViewModel>>> GetLivros()
        {
            var livros = await _repository.GetAllLivro();

            if (!livros.Any())
            {
                return ResultViewModel<List<LivroViewModel>>.Error("Nenhum livro encontrado.");
            }

            var result = livros.Select(o => LivroViewModel.FromEntity(o)).ToList();

            return ResultViewModel<List<LivroViewModel>>.Sucess(result);
        }

        public async Task<ResultViewModel<LivroViewModel>> PostLivro(LivroInputModel model)
        {
            var livro = model.ToEntity();

            await _repository.PostLivro(livro);

            var result = LivroViewModel.FromEntity(livro);

            return ResultViewModel<LivroViewModel>.Sucess(result);
        }
    }
}
