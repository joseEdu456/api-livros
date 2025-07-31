using api_livros.Core.Entities;
using api_livros.Core.Interfaces;
using api_livros.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace api_livros.Infrastructure.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LivroDbContext _db;
        public LivroRepository(LivroDbContext db)
        {
            _db = db;
        }

        public async Task DeleteLivro(Livro livro)
        {
            _db.Livros.Update(livro);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Livro>> GetAllLivro()
        {
            return await _db.Livros.Where(o => !o.IsDeleted).ToListAsync();
        }

        public async Task<Livro?> GetLivroById(int id)
        {
            return await _db.Livros.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task PostLivro(Livro livro)
        {
            await _db.Livros.AddAsync(livro);
            await _db.SaveChangesAsync();
        }
    }
}
