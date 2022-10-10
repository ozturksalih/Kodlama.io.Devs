using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IMapper _mapper;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _mapper = mapper;
            }

            public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaimToBeAdded = _mapper.Map<UserOperationClaim>(request);

                await _userOperationClaimBusinessRules.UserAndOperationClaimMustExistInDbWhenInserted(request.UserId, request.OperationClaimId);

                await _userOperationClaimBusinessRules.UserOperationClaimCanNotBeDuplicatedWhenInserted(userOperationClaimToBeAdded);

                var added = await _userOperationClaimRepository.AddAsync(userOperationClaimToBeAdded);

                CreatedUserOperationClaimDto responseDto = _mapper.Map<CreatedUserOperationClaimDto>(added);

                return responseDto;

            }
        }
    }
}
