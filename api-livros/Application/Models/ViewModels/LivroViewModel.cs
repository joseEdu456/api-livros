using api_livros.Core.Entities;

namespace api_livros.Application.Models.ViewModels
{
    public class LivroViewModel
    {

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public int AnoPublicacao { get; private set; }
        public LivroViewModel(int id, string titulo, string autor, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
        }

        public static LivroViewModel FromEntity(Livro livro)
        {
            return new LivroViewModel(livro.Id, livro.Titulo, livro.Autor, livro.AnoPublicacao);
        }
    }
}
