using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void UserMustExistWhenRequested(User user)
        {
            if (user == null) throw new BusinessException("User must exist.");
        }

        public void VerifyUserPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool verified = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!verified) throw new AuthorizationException("Entered password is wrong");

        }
    }
}
