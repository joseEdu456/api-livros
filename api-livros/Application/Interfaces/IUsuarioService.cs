using api_livros.Application.Models.InputModels;
using api_livros.Application.Models.ViewModels;

namespace api_livros.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<ResultViewModel<List<UsuarioViewModel>>> GetUsuarios();
        Task<ResultViewModel<UsuarioViewModel>> GetUsuarioById(int id);
        Task<ResultViewModel<UsuarioViewModel>> PostUsuario(UsuarioInputModel model);
        Task<ResultViewModel> PutUsuario(AlteracaoUsuarioInputModel model);
        Task<ResultViewModel> DeleteUsuario(int id);
    }
}
