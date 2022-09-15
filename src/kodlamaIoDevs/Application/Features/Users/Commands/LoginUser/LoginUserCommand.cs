using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : UserForLoginDto, IRequest<LoggedUserDto>
    {
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoggedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly UserBusinessRules _userBusinessRules;

            public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _userBusinessRules = userBusinessRules;
            }

            public async  Task<LoggedUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User? userToLogin = await _userRepository.GetAsync(u => u.Email == request.Email);

                _userBusinessRules.UserMustExistWhenRequested(userToLogin);

                _userBusinessRules.VerifyUserPassword(request.Password, userToLogin.PasswordHash, userToLogin.PasswordSalt) ;

                List<OperationClaim> operationClaims = new List<OperationClaim>();
                AccessToken accessToken = _tokenHelper.CreateToken(userToLogin, operationClaims);

                LoggedUserDto loggedUserDto = _mapper.Map<LoggedUserDto>(accessToken);
                return loggedUserDto;

            }
        }
    }
}
