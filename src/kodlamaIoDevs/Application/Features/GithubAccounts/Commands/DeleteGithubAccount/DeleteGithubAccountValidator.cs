using FluentValidation;

namespace Application.Features.GithubAccounts.Commands.DeleteGithubAccount
{
    public class DeleteGithubAccountValidator : AbstractValidator<DeleteGithubAccountCommand>
    {
        public DeleteGithubAccountValidator()
        {
            RuleFor(g => g.Id).NotNull();
        }
    }
}
