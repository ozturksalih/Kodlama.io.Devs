using Application.Features.Members.Dtos;
using Application.Features.Members.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;

namespace Application.Features.Members.Commands.LoginMember
{
    public class LoginMemberCommand : UserForLoginDto, IRequest<LoggedMemberDto>
    {
        public class LoginMemberCommandHandler : IRequestHandler<LoginMemberCommand, LoggedMemberDto>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly MemberBusinessRules _memberBusinessRules;

            public LoginMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper, ITokenHelper tokenHelper, MemberBusinessRules memberBusinessRules)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _memberBusinessRules = memberBusinessRules;
            }

            public async Task<LoggedMemberDto> Handle(LoginMemberCommand request, CancellationToken cancellationToken)
            {
                Member? memberToLogin = await _memberRepository.GetAsync(m => m.Email == request.Email);

                _memberBusinessRules.MemberMustExistWhenRequested(memberToLogin);
                _memberBusinessRules.VerifyMemberPassword(request.Password, memberToLogin.PasswordHash, memberToLogin.PasswordSalt);

                List<OperationClaim> operationClaims = new List<OperationClaim>();
                AccessToken accessToken = _tokenHelper.CreateToken(memberToLogin, operationClaims);

                LoggedMemberDto loggedMemberDto = _mapper.Map<LoggedMemberDto>(accessToken);

                return loggedMemberDto;


            }
        }
    }
}
