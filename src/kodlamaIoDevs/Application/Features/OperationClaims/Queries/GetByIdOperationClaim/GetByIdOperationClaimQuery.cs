﻿using Application.Enums;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQuery : IRequest<GetByIdOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { ClaimRoles.admin.ToString() };

        public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, GetByIdOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<GetByIdOperationClaimDto> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);
                _operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(operationClaim);

                GetByIdOperationClaimDto getByIdOperationClaimDto = _mapper.Map<GetByIdOperationClaimDto>(operationClaim);

                return getByIdOperationClaimDto;
            }
        }
    }
}
