using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(o => o.Name == name);
            if (result.Items.Any()) throw new BusinessException("OperationClaim exists.");

        }
        public void OperationClaimShouldExistWhenRequested(OperationClaim operationClaim)
        {
            if (operationClaim == null) throw new BusinessException("Requested operationClaim does not exist");
        }
    }
}
