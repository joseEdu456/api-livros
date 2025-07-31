using api_livros.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace api_livros.Core.Interfaces
{
    public interface ILivroRepository
    {
        Task<List<Livro>> GetAllLivro();
        Task<Livro?> GetLivroById(int id);
        Task PostLivro(Livro livro);
        Task DeleteLivro(Livro livro);
    }
}
