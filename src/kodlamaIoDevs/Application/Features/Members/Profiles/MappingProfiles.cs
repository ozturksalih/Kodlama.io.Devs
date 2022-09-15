using Application.Features.Members.Commands.LoginMember;
using Application.Features.Members.Commands.RegisterMember;
using Application.Features.Members.Dtos;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.JWT;
using Domain.Entities;

namespace Application.Features.Members.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Member, RegisterMemberCommand>().ReverseMap();
            CreateMap<Member, RegisteredMemberDto>().ReverseMap();

            CreateMap<Member, LoginMemberCommand>().ReverseMap();
            CreateMap<AccessToken, LoggedMemberDto>().ReverseMap();
            CreateMap<Member, UserForLoginDto>().ReverseMap();
        }
    }
}
