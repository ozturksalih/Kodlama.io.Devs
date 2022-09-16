using FluentValidation;

namespace Application.Features.GithubAccounts.Queries.GetGithubAccountByMemberId
{
    public class GetGithubAccountByMemberIdValidator : AbstractValidator<GetGithubAccountByMemberIdQuery>
    {
        public GetGithubAccountByMemberIdValidator()
        {
            RuleFor(g => g.MemberId).NotNull();
        }
    }
}