using FluentValidation;

namespace Application.Features.GithubAccounts.Commands.CreateGithubAccount
{
    public class CreateGithubAccountValidator : AbstractValidator<CreateGithubAccountCommand>
    {
        public CreateGithubAccountValidator()
        {
            
            RuleFor(g => g.GithubLink).NotNull().NotEmpty();
        }
    }
}
