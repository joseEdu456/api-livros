using api_livros.Application.Models.InputModels;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace api_livros.Application.Validadors
{
    public class UsuarioInputModelValidator : AbstractValidator<UsuarioInputModel>
    {
        public UsuarioInputModelValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                    .WithMessage("Nome não pode estar vazio.")
                .Must(u => !u.Equals("string"))
                    .WithMessage("Nome não pode ser 'string'.");

            RuleFor(u => u.Email)
                .NotEmpty()
                    .WithMessage("Nome não pode estar vazio.")
                .EmailAddress()
                    .WithMessage("Email não é válido");
        }
    }
}
