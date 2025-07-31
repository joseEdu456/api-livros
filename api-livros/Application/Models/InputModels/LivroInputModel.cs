using api_livros.Core.Entities;

namespace api_livros.Application.Models.InputModels
{
    public class LivroInputModel
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }
        public LivroInputModel(string titulo, string autor, string iSBN, int anoPublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }

        public Livro ToEntity()
        {
            return new Livro(Titulo, Autor, ISBN, AnoPublicacao);
        }
    }
}
