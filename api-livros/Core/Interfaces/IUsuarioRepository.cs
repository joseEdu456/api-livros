using api_livros.Core.Entities;

namespace api_livros.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetUsuario();
        Task<Usuario?> GetUsuarioById(int id);
        Task PostUsuario(Usuario usuario);
        Task PutUsuario(Usuario usuario);
        Task DeleteUsuario(Usuario usuario);
    }
}
