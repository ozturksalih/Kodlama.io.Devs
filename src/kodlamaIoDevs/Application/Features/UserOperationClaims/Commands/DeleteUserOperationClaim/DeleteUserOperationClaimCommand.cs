using Application.Enums;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { ClaimRoles.admin.ToString() };


        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimDto>
        {
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public DeleteUserOperationClaimCommandHandler(UserOperationClaimBusinessRules userOperationClaimBusinessRules, IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim?  userOperationClaimToBeDeleted = await _userOperationClaimRepository.GetAsync(u => u.Id == request.Id);

                _userOperationClaimBusinessRules.UserOperationClaimShouldExistWhenRequested(userOperationClaimToBeDeleted);

                UserOperationClaim result = await _userOperationClaimRepository.DeleteAsync(userOperationClaimToBeDeleted);

                DeletedUserOperationClaimDto responseDto = _mapper.Map<DeletedUserOperationClaimDto>(result);

                return responseDto;
            }
        }
    }
}
