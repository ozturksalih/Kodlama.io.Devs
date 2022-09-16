using Application.Features.Core.Core.Command;
using Application.Features.GithubAccounts.Dtos;
using Application.Features.GithubAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubAccounts.Commands.CreateGithubAccount
{
    public class CreateGithubAccountCommand : IRequest<CreatedGithubAccountDto>
    {
        public int MemberId { get; set; }
        public string GithubLink { get; set; }
        public class CreateGithubAccountCommandHandler : BaseCommandHandler<IGithubAccountRepository, GithubAccountBusinessRules>, 
            IRequestHandler<CreateGithubAccountCommand, CreatedGithubAccountDto>
        {
            public CreateGithubAccountCommandHandler(IGithubAccountRepository repository, IMapper mapper, GithubAccountBusinessRules businessRules) : base(repository, mapper, businessRules)
            {
            }

            public async Task<CreatedGithubAccountDto> Handle(CreateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                GithubAccount githubAccount = _mapper.Map<GithubAccount>(request);

                GithubAccount addedGithubAccount = await _repository.AddAsync(githubAccount);

                CreatedGithubAccountDto createdGithubAccountDto = _mapper.Map<CreatedGithubAccountDto>(addedGithubAccount);
                return createdGithubAccountDto;

            }
        }
    }
}
