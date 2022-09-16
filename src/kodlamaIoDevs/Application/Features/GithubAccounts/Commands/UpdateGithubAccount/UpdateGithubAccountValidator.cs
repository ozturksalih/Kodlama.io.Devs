using FluentValidation;

namespace Application.Features.GithubAccounts.Commands.UpdateGithubAccount
{
    public class UpdateGithubAccountValidator : AbstractValidator<UpdateGithubAccountCommand>
    {
        public UpdateGithubAccountValidator()
        {
            RuleFor(g => g.Id).NotNull();
            RuleFor(g=> g.MemberId).NotNull();

            
        }
    }
}
