using api_livros.Core.Interfaces;
using api_livros.Infrastructure.Persistence;
using api_livros.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace api_livros.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext(configuration)
                .AddRepository();

            return services;
        }

        private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LivroDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("ApiLivroConnection")));

            return services;
        }

        private static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
