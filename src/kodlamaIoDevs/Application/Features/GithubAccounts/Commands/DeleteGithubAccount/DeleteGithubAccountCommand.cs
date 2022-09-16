using Application.Features.Core.Core.Command;
using Application.Features.GithubAccounts.Dtos;
using Application.Features.GithubAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubAccounts.Commands.DeleteGithubAccount
{
    public class DeleteGithubAccountCommand : IRequest<DeletedGithubAccountDto>
    {
        public int Id { get; set; }
        public class DeleteGithubAccountCommandHandler : BaseCommandHandler<IGithubAccountRepository, GithubAccountBusinessRules>, 
            IRequestHandler<DeleteGithubAccountCommand, DeletedGithubAccountDto>
        {
            public DeleteGithubAccountCommandHandler(IGithubAccountRepository repository, IMapper mapper, GithubAccountBusinessRules businessRules) : base(repository, mapper, businessRules)
            {
            }

            public async Task<DeletedGithubAccountDto> Handle(DeleteGithubAccountCommand request, CancellationToken cancellationToken)
            {
                GithubAccount githubAccount = await _repository.GetAsync(m => m.Id == request.Id);

                _businessRules.GithubAccountMustExistWhenRequested(githubAccount);

                GithubAccount githubAccountToBeDeleted = await _repository.DeleteAsync(githubAccount);

                DeletedGithubAccountDto deletedGithubAccountDto = _mapper.Map<DeletedGithubAccountDto>(githubAccountToBeDeleted);
                return deletedGithubAccountDto;
            }
        }
    }
}
