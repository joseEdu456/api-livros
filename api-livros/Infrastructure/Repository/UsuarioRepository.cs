using api_livros.Core.Entities;
using api_livros.Core.Interfaces;
using api_livros.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace api_livros.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LivroDbContext _db;
        public UsuarioRepository(LivroDbContext db)
        {
            _db = db;
        }

        public async Task DeleteUsuario(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetUsuario()
        {
            return await _db.Usuarios.Where(u => !u.IsDeleted).ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioById(int id)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task PostUsuario(Usuario usuario)
        {
            await _db.Usuarios.AddAsync(usuario);
            await _db.SaveChangesAsync();
        }

        public async Task PutUsuario(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            await _db.SaveChangesAsync();
        }
    }
}
