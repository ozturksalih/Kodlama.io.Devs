using Application.Features.Users.Commands.LoginUser;
using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Dtos;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, RegisteredUserDto>().ReverseMap();

            CreateMap<User, LoginUserCommand>().ReverseMap();
            CreateMap<AccessToken, LoggedUserDto>().ReverseMap();
            CreateMap<User, UserForLoginDto>().ReverseMap();
        }
    }
}
