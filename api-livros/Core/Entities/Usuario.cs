using api_livros.Application.Models.InputModels;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace api_livros.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public void AlterarDados(AlteracaoUsuarioInputModel model)
        {
            Nome = model.Nome;
            Email = model.Email;
        }
        
    }
}
