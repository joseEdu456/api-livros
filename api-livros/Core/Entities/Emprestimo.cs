namespace api_livros.Core.Entities
{
    public class Emprestimo : BaseEntity
    {

        public int IdUsuario { get; private set; }
        public Usuario? Usuario { get; private set; }
        public int IdLivro { get; private set; }
        public Livro? Livro { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public Emprestimo(int idUsuario, int idLivro) : base()
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataEmprestimo = DateTime.Now;
        }

    }
}
