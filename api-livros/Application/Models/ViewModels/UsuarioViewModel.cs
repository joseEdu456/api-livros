using api_livros.Core.Entities;

namespace api_livros.Application.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public UsuarioViewModel(int id, string nome, string email, DateTime dataCriacao)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataCriacao = dataCriacao;
        }
        
        public static UsuarioViewModel FromEntity(Usuario user)
        {
            return new UsuarioViewModel(user.Id, user.Nome, user.Email, user.CreatedAt);
        }
    }
}
