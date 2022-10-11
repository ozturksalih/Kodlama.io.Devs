using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaims
{
    public class GetByUserIdUserOperationClaimsQuery : IRequest<GetUserOperationClaimListModel>
    {
        public int UserId { get; set; }

        public class GetByUserIdUserOperationClaimsQueryHandler : IRequestHandler<GetByUserIdUserOperationClaimsQuery, GetUserOperationClaimListModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public GetByUserIdUserOperationClaimsQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<GetUserOperationClaimListModel> Handle(GetByUserIdUserOperationClaimsQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> claims = await _userOperationClaimRepository
                    .GetListAsync(c => c.UserId == request.UserId, include: m=> m.Include(m => m.OperationClaim).Include(m=> m.User));

                GetUserOperationClaimListModel getUserOperationClaimListModel = _mapper.Map<GetUserOperationClaimListModel>(claims);

                return getUserOperationClaimListModel;
            }
        }
    }
}
