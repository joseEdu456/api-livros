using api_livros.Core.Entities;

namespace api_livros.Application.Models.InputModels
{
    public class EmprestimoInputModel
    {
        public EmprestimoInputModel(int idUsuario, int idLivro)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
        }

        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }

        public Emprestimo ToEntity()
        {
            return new Emprestimo(IdUsuario, IdLivro);
        }

    }
}
