using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserRepository _userRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository, IUserRepository userRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _operationClaimRepository = operationClaimRepository;
            _userRepository = userRepository;
        }

        public async Task UserOperationClaimCanNotBeDuplicatedWhenInserted(UserOperationClaim userOperationClaim)
        {
            IPaginate <UserOperationClaim> result = await _userOperationClaimRepository.GetListAsync(u => u.UserId == userOperationClaim.UserId && u.OperationClaimId == userOperationClaim.OperationClaimId);

            if (result.Items.Any()) throw new BusinessException("Entered Operation Claim for this user already exist!");
        }

        public async Task UserAndOperationClaimMustExistInDbWhenInserted(int userId, int operationClaimId)
        {
            await UserMustExistInDbWhenRequested(userId);

            await OperationClaimMustExistInDbWhenRequested(operationClaimId);
        }

        public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException("Entered operation claim for this user doesn't exist!");
        }

        private async Task UserMustExistInDbWhenRequested(int userId)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == userId);

            if (user == null) throw new BusinessException("Entered user doesn't exist!");
        }

        private async Task OperationClaimMustExistInDbWhenRequested(int operationClaimId)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(u => u.Id == operationClaimId);

            if (operationClaim == null) throw new BusinessException("Entered operation claim doesn't exist!");
        }
        

    }
}
