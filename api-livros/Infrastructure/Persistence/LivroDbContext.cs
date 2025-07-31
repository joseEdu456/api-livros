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
        }
    }
}
