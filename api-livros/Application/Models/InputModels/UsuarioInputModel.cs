using api_livros.Core.Entities;

namespace api_livros.Application.Models.InputModels
{
    public class UsuarioInputModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public UsuarioInputModel(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public Usuario ToEntity()
        {
            return new Usuario(Nome, Email);
        }

    }
}
