using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageValidator()
        {
            RuleFor(pl => pl.Name).NotEmpty();
            RuleFor(pl => pl.Name).MinimumLength(2);
        }
    }
}
