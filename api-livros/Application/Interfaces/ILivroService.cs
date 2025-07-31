using api_livros.Application.Models.InputModels;
using api_livros.Application.Models.ViewModels;

namespace api_livros.Application.Interfaces
{
    public interface ILivroService
    {
        Task<ResultViewModel> DeleteLivro(int id);
        Task<ResultViewModel<LivroViewModel>> GetLivroById(int id);
        Task<ResultViewModel<List<LivroViewModel>>> GetLivros();
        Task<ResultViewModel<LivroViewModel>> PostLivro(LivroInputModel model);
    }
}
