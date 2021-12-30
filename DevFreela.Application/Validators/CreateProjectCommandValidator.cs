using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validator{
    public class CreateProjectCommandValidator:AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
                RuleFor(cp=>cp.Title)
                    .Length(1,50)
                    .NotEmpty()
                    .WithMessage("Tamanho não válido");

                RuleFor(cp=>cp.Title)
                    .NotNull()
                    .WithMessage("Titulo nao pode ser nulo");
        }
    }
}