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
        public class CreateGithubAccountCommandHandler : IRequestHandler<CreateGithubAccountCommand, CreatedGithubAccountDto>
        {
            private readonly IGithubAccountRepository _githubAccountRepository;
            private readonly IMapper _mapper;
            private readonly GithubAccountBusinessRules _githubAccountBusinessRules;

            public CreateGithubAccountCommandHandler(IGithubAccountRepository githubAccountRepository, IMapper mapper, GithubAccountBusinessRules githubAccountBusinessRules)
            {
                _githubAccountRepository = githubAccountRepository;
                _mapper = mapper;
                _githubAccountBusinessRules = githubAccountBusinessRules;
            }

            public async Task<CreatedGithubAccountDto> Handle(CreateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                GithubAccount githubAccount = _mapper.Map<GithubAccount>(request);

                GithubAccount addedGithubAccount = await _githubAccountRepository.AddAsync(githubAccount);

                CreatedGithubAccountDto createdGithubAccountDto = _mapper.Map<CreatedGithubAccountDto>(addedGithubAccount);
                return createdGithubAccountDto;

            }
        }
    }
}
