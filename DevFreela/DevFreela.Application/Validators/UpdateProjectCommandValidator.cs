using DevFreela.Application.Commands.UpdateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class UpdateProjectCommandValidator: AbstractValidator<UpdateProjectCommand> 
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(up=>up.Description)
                .NotNull()
                .WithMessage("Descricao não pode ser null");
                
        }
    }
}