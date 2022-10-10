using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaims
{
    public class GetByUserIdUserOperationClaimsQuery : IRequest<GetUserOperationClaimListModel>
    {
        public int UserId { get; set; }

        public class GetByUserIdUserOperationClaimsQueryHandler : IRequestHandler<GetByUserIdUserOperationClaimsQuery, GetUserOperationClaimListModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public Task<GetUserOperationClaimListModel> Handle(GetByUserIdUserOperationClaimsQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
