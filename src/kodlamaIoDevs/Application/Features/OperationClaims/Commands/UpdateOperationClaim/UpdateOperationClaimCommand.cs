using Application.Enums;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand : IRequest<UpdatedClaimOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string[] Roles => new[] { ClaimRoles.admin.ToString() };


        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedClaimOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }


            public async Task<UpdatedClaimOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);
                _operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(operationClaim);

                await _operationClaimBusinessRules.OperationClaimCanNotBeDuplicatedWhenInserted(request.Name);

                operationClaim.Name = request.Name;

                await _operationClaimRepository.UpdateAsync(operationClaim);

                UpdatedClaimOperationClaimDto updatedClaimOperationClaimDto = _mapper.Map<UpdatedClaimOperationClaimDto>(operationClaim);

                return updatedClaimOperationClaimDto;
                

            }
        }
    }
}
