namespace api_livros.Application.Models.InputModels
{
    public class AlteracaoUsuarioInputModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public AlteracaoUsuarioInputModel(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
    }
}
