using Application.Features.Members.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Members.Commands.RegisterMember
{
    public class RegisterMemberCommand : UserForRegisterDto, IRequest<RegisteredMemberDto>
    {

        public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, RegisteredMemberDto>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly IMapper _mapper;

            public RegisterMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
            }

            public async Task<RegisteredMemberDto> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
            {
                Member mappedMember = _mapper.Map<Member>(request);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                mappedMember.PasswordHash = passwordHash;
                mappedMember.PasswordSalt = passwordSalt;
                mappedMember.Status = true;

                Member createdMember = await _memberRepository.AddAsync(mappedMember);

                RegisteredMemberDto registeredMemberDto = _mapper.Map<RegisteredMemberDto>(createdMember);

                return registeredMemberDto;
            }
        }
    }
}
