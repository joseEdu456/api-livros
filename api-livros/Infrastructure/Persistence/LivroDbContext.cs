using api_livros.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_livros.Infrastructure.Persistence
{
    public class LivroDbContext : DbContext
    {
        public LivroDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>(l =>
            {
                l.HasKey(l => l.Id);

                l.Property(l => l.Titulo).HasColumnType("VARCHAR(100)");
                l.Property(l => l.Autor).HasColumnType("VARCHAR(50)");
                l.Property(l => l.ISBN).HasColumnType("VARCHAR(30)");
                l.Property(l => l.AnoPublicacao).HasColumnType("SMALLINT");
            });

            modelBuilder.Entity<Usuario>(u =>
            {
                u.HasKey(u => u.Id);

                u.Property(u => u.Nome).HasColumnType("VARCHAR(100)");
                u.Property(u => u.Email).HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<Emprestimo>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasOne(u => u.Usuario)
                    .WithMany(u => u.Emprestimos)
                    .HasForeignKey(u => u.IdUsuario)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.Livro)
                    .WithOne(l => l.Emprestimo)
                    .HasForeignKey<Emprestimo>(e => e.IdLivro)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
