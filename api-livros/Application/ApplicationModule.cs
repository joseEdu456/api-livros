using api_livros.Application.Interfaces;
using api_livros.Application.Models.InputModels;
using api_livros.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace api_livros.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddValidation();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<LivroInputModel>();

            return services;
        }
    }
}
