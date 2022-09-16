using Application.Features.Core.Core.Command;
using Application.Features.GithubAccounts.Dtos;
using Application.Features.GithubAccounts.Rules;
using Application.Features.Members.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubAccounts.Commands.UpdateGithubAccount
{
    public class UpdateGithubAccountCommand : IRequest<UpdatedGithubAccountDto>
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string GithubLink { get; set; }
        public class UpdateGithubAccountCommandHandler : BaseCommandHandler<IGithubAccountRepository, GithubAccountBusinessRules>,
            IRequestHandler<UpdateGithubAccountCommand, UpdatedGithubAccountDto>
        {
            private readonly MemberBusinessRules _memberBusinessRules;
            public UpdateGithubAccountCommandHandler(IGithubAccountRepository repository, IMapper mapper, GithubAccountBusinessRules businessRules, MemberBusinessRules memberBusinessRules) : base(repository, mapper, businessRules)
            {
                _memberBusinessRules = memberBusinessRules;
            }

            public async Task<UpdatedGithubAccountDto> Handle(UpdateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                GithubAccount? githubAccount = await _repository.GetAsync(g => g.Id == request.Id);

                _businessRules.GithubAccountMustExistWhenRequested(githubAccount);
                await _memberBusinessRules.CheckIsMemberExistByIdAsync(request.MemberId);


                githubAccount.MemberId = request.MemberId;
                githubAccount.GithubLink = request.GithubLink;

                GithubAccount updatedGithubAccount = await _repository.UpdateAsync(githubAccount);

                UpdatedGithubAccountDto updatedGithubAccountDto = _mapper.Map<UpdatedGithubAccountDto>(updatedGithubAccount);
                return updatedGithubAccountDto;
            }
        }
    }
}
