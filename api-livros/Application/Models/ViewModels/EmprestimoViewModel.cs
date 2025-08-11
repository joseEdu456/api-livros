using api_livros.Core.Entities;

namespace api_livros.Application.Models.ViewModels
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel(string? nomeLivro, string? nomeUsuario, DateTime dataEmprestimo)
        {
            NomeLivro = nomeLivro;
            NomeUsuario = nomeUsuario;
            DataEmprestimo = dataEmprestimo;
        }

        public string? NomeLivro { get; private set; }
        public string? NomeUsuario { get; private set; }
        public DateTime DataEmprestimo { get; private set; }

        public static EmprestimoViewModel FromEntity(Emprestimo entity)
        {
            return new EmprestimoViewModel(entity.Livro?.Titulo, entity.Usuario?.Nome, entity.DataEmprestimo);
        }
    }
}
