using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;
using Domain.Entities;

namespace Application.Features.Members.Rules
{
    public class MemberBusinessRules
    {
        private readonly IMemberRepository _memberRepository;

        public MemberBusinessRules(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public void MemberMustExistWhenRequested(Member member)
        {
            if (member == null) throw new BusinessException("Member must exist.");
        }

        public async Task CheckIsMemberExistByIdAsync(int id)
        {
            Member? member = await _memberRepository.GetAsync(m => m.Id == id);
            MemberMustExistWhenRequested(member);
        }

        public void VerifyMemberPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool verified = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!verified) throw new AuthorizationException("Entered password is wrong");

        }
    }
}
