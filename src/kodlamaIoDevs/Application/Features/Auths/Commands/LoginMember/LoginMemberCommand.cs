using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using static Application.Features.Auths.Commands.RegisterMember.RegisterCommand;

namespace Application.Features.Auths.Commands.LoginMember
{
    public class LoginMemberCommand : UserForLoginDto, IRequest<LoggedMemberDto>
    {
        public class LoginMemberCommandHandler : IRequestHandler<LoginMemberCommand, LoggedMemberDto>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoggedMemberDto> Handle(LoginMemberCommand request, CancellationToken cancellationToken)
            {
                Member? memberToLogin = await _memberRepository.GetAsync(m => m.Email == request.Email);

                _authBusinessRules.MemberMustExistWhenRequested(memberToLogin);
                _authBusinessRules.VerifyMemberPassword(request.Password, memberToLogin.PasswordHash, memberToLogin.PasswordSalt);

                List<OperationClaim> operationClaims = new List<OperationClaim>();
                AccessToken accessToken = _tokenHelper.CreateToken(memberToLogin, operationClaims);

                LoggedMemberDto loggedMemberDto = _mapper.Map<LoggedMemberDto>(accessToken);

                return loggedMemberDto;


            }
        }
    }
}
