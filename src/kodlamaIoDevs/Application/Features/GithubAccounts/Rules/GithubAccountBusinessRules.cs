using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Features.GithubAccounts.Rules
{
    public class GithubAccountBusinessRules
    {
        private readonly IGithubAccountRepository _githubAccountRepository;

        public GithubAccountBusinessRules(IGithubAccountRepository githubAccountRepository)
        {
            _githubAccountRepository = githubAccountRepository;
        }

        public void GithubAccountMustExistWhenRequested(GithubAccount githubAccount)
        {
            if (githubAccount == null) throw new BusinessException("Github Account must exist.");
        }
    }
}
