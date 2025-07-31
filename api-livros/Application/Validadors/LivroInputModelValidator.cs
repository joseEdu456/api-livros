using api_livros.Application.Models.InputModels;
using FluentValidation;

namespace api_livros.Application.Validadors
{
    public class LivroInputModelValidator : AbstractValidator<LivroInputModel>
    {
        public LivroInputModelValidator()
        {
            RuleFor(l => l.Titulo)
                .NotEmpty()
                    .WithMessage("Titulo não pode ser vazio.");

            RuleFor(l => l.Autor)
                .NotEmpty()
                    .WithMessage("Autor não pode ser vazio.");

            RuleFor(l => l.ISBN)
                .NotEmpty()
                    .WithMessage("ISBN não pode ser vazio.");

            RuleFor(l => l.AnoPublicacao)
                .GreaterThanOrEqualTo(1900)
                    .WithMessage("Ano de publicação deve ser maior que 1900.")
                .LessThanOrEqualTo(DateTime.Now.Year)
                    .WithMessage("Ano de publicação deve ser menor ou igual ao ano atual");
        }
    }
}
