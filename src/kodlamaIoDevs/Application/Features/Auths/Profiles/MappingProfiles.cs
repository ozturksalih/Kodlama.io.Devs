
using Application.Features.Auths.Commands.LoginMember;
using Application.Features.Auths.Commands.RegisterMember;

using Application.Features.Auths.Dtos;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.JWT;
using Domain.Entities;

namespace Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Member, RegisterCommand>().ReverseMap();
            CreateMap<Member, RegisteredDto>().ReverseMap();

            CreateMap<Member, LoginMemberCommand>().ReverseMap();
            CreateMap<AccessToken, LoggedMemberDto>().ReverseMap();
            CreateMap<Member, UserForLoginDto>().ReverseMap();
        }
    }
}
